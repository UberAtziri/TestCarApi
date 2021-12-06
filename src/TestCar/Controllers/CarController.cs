using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCar.Business.Services.Interfaces;
using TestCar.Core.Common;
using TestCar.Models.Cars;
using TestCar.Models.Mappers;

namespace TestCar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public async Task<List<CarResponseModel>> Get([FromQuery] PaginationOptions options)
        {
            var result = await this.carService.GetCars(options);

            return result.ToCarResponses();
        }
        
        [HttpPost]
        public async Task<CarResponseModel> Post([FromBody] CarCreateModel createModel)
        {
            var result = await this.carService.AddCar(createModel);

            return result.ToCarResponse();
        }
        
        [HttpPut]
        public async Task<CarResponseModel> Update([FromBody] CarUpdateModel updateModel)
        {
            var result = await this.carService.UpdateCar(updateModel);

            return result.ToCarResponse();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<CarResponseModel> Delete(int id)
        {
            var result = await this.carService.DeleteCar(id);

            return result.ToCarResponse();
        }
        
        [HttpPost]
        [Route("email")]
        public async Task<string> SendCarInformationEmail(string emailTo)
        {
            return await this.carService.SendEmailWithCarsInformation(emailTo);
        }
    }
}