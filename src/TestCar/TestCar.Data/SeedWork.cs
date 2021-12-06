using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TestCar.Data.Models;

namespace TestCar.Data
{
    public static class SeedInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<CarContext>())
            {
                if (context == null || context.Cars == null || context.Cars.Any())
                {
                    return;
                }

                var toAdd = new List<CarEntity>
                {
                    new CarEntity
                    {
                        Vendor = "VAZ",
                        Model = "2107"
                    },
                    new CarEntity
                    {
                        Vendor = "VAZ",
                        Model = "2109"
                    },
                    new CarEntity
                    {
                        Vendor = "KAMAZ",
                        Model = "test"
                    },
                    new CarEntity
                    {
                        Vendor = "test",
                        Model = "test"
                    },
                    new CarEntity
                    {
                        Vendor = "ZAZ",
                        Model = "Zaporozhec"
                    },
                    new CarEntity
                    {
                        Vendor = "Tesla",
                        Model = "HZ"
                    },
                    new CarEntity
                    {
                        Vendor = "BMW",
                        Model = "HZ"
                    },
                    new CarEntity
                    {
                        Vendor = "Valve",
                        Model = "Index"
                    },
                    new CarEntity
                    {
                        Vendor = "ZXC",
                        Model = "1000-7"
                    }
                };
                context.AddRange(toAdd);
                context.SaveChanges();
            }
        }
    }
}