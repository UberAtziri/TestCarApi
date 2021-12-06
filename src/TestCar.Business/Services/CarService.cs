using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCar.Business.Mappers;
using TestCar.Business.Services.Interfaces;
using TestCar.Core.Common;
using TestCar.Core.Exceptions;
using TestCar.Data.Models;
using TestCar.Data.Repositories.Interfaces;

namespace TestCar.Business.Services
{
    public class CarService : ICarService
    {
        private readonly IEmailService emailService;
        private readonly IRepository<CarEntity> carRepo;

        public CarService(IEmailService emailService, IRepository<CarEntity> carRepo)
        {
            this.emailService = emailService;
            this.carRepo = carRepo;
        }

        public async Task<List<CarDomain>> GetCars(PaginationOptions options)
        {
            var entities = await this.carRepo
                .GetAll()
                .Take(options.PageSize)
                .ToListAsync();

            return entities.ToCarDomains();
        }

        public async Task<CarDomain> UpdateCar(CarUpdateModel updateModel)
        {
            var targetCar = await this.carRepo.Get(updateModel.Id);

            if (targetCar == null)
            {
                throw new CarNotFoundException(updateModel.Id);
            }

            targetCar.Model = updateModel.Model;
            targetCar.Vendor = updateModel.Vendor;

            await this.carRepo.Update(targetCar);

            return targetCar.ToCarDomain();
        }

        public async Task<CarDomain> DeleteCar(int id)
        {
            var targetCar = await this.carRepo.Get(id);

            if (targetCar == null)
            {
                throw new CarNotFoundException(id);
            }

            var result = await this.carRepo.Delete(targetCar);

            return result.ToCarDomain();
        }

        public async Task<CarDomain> AddCar(CarCreateModel createModel)
        {
            var toAdd = createModel.ToCarEntity();

            var result = await this.carRepo.Create(toAdd);
            
            return result.ToCarDomain();
        }

        public async Task<string> SendEmailWithCarsInformation(string emailTo)
        {
            var cars = await this.carRepo.GetAll().ToListAsync();
            var message = this.BuildCarListMessage(cars.ToCarDomains());
            
            this.emailService.SendEmail(message, emailTo);

            return message;
        }

        private string BuildCarListMessage(IEnumerable<CarDomain> carDomains)
        {
            var sb = new StringBuilder();

            foreach (var carDomain in carDomains)
            {
                sb.AppendLine($"{nameof(carDomain.Model)}: {carDomain.Model}");
                sb.AppendLine($"{nameof(carDomain.Vendor)}: {carDomain.Vendor}");
                sb.AppendLine(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}