using Microsoft.Extensions.DependencyInjection;
using TestCar.Data.Models;
using TestCar.Data.Repositories;
using TestCar.Data.Repositories.Interfaces;

namespace TestCar.Data.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRepository<CarEntity>, Repository<CarEntity>>();

            return serviceCollection;
        }
    }
}