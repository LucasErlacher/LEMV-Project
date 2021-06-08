using LEMV.Data.Repositories;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace LEMV.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
                                                                Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            //Injeção de Dependência
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<NewsRepository>();

            //AD Config
            var section = configuration.GetSection("ActiveDirectory");
            services.Configure<ActiveDirectory>(section);

            return services;
        }
    }
}