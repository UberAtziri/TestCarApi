using System.Collections.Generic;
using System.Linq;
using TestCar.Core.Common;
using TestCar.Data.Models;

namespace TestCar.Business.Mappers
{
    public static class CarMapper
    {
        public static List<CarDomain> ToCarDomains(this IEnumerable<CarEntity> entities)
        {
            if (entities == null)
            {
                return new List<CarDomain>();
            }
            
            var domains = entities.Select(ToCarDomain).ToList();

            return domains;
        }

        public static CarDomain ToCarDomain(this CarEntity entity)
        {
            if (entity == null)
            {
                return default;
            }
            
            var domain = new CarDomain
            {
                Id = entity.Id,
                Vendor = entity.Vendor,
                Model = entity.Model
            };

            return domain;
        }

        public static CarEntity ToCarEntity(this CarCreateModel createModel)
        {
            if (createModel == null)
            {
                return default;
            }
            
            var entity = new CarEntity
            {
                Vendor = createModel.Vendor,
                Model = createModel.Model
            };

            return entity;
        }
    }
}