using System.Collections.Generic;
using System.Threading.Tasks;
using TestCar.Core.Common;

namespace TestCar.Business.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<CarDomain>> GetCars(PaginationOptions options);
        
        Task<CarDomain> UpdateCar(CarUpdateModel updateModel);
        
        Task<CarDomain> DeleteCar(int id);
        
        Task<CarDomain> AddCar(CarCreateModel createModel);

        Task<string> SendEmailWithCarsInformation(string emailTo);
    }
}