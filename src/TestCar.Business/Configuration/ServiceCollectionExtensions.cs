using Microsoft.Extensions.DependencyInjection;
using TestCar.Business.Services;
using TestCar.Business.Services.Interfaces;

namespace TestCar.Business.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICarService, CarService>();
            serviceCollection.AddTransient<IEmailService, EmailService>();

            return serviceCollection;
        }
    }
}