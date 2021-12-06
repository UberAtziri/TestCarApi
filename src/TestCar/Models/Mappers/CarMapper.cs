using System.Collections.Generic;
using System.Linq;
using TestCar.Core.Common;
using TestCar.Models.Cars;

namespace TestCar.Models.Mappers
{
    public static class CarMapper
    {
        public static CarResponseModel ToCarResponse(this CarDomain domain)
        {
            if (domain == null)
            {
                return default;
            }
            
            var response = new CarResponseModel
            {
                Id = domain.Id,
                Vendor = domain.Vendor,
                Model = domain.Model
            };

            return response;
        }

        public static List<CarResponseModel> ToCarResponses(this IEnumerable<CarDomain> domains)
        {
            if (domains == null)
            {
                return new List<CarResponseModel>();
            }

            var responses = domains.Select(ToCarResponse).ToList();

            return responses;
        }
    }
}