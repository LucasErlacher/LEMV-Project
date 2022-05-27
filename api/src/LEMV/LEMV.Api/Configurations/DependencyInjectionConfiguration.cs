using LEMV.Application.Services;
using LEMV.Application.Services.Interfaces;
using LEMV.Data.Repositories;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using LEMV.Domain.Services;
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


            services.AddScoped<INewsAppService, NewsAppService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsRepository, NewsRepository>();


            //AD Config
            var section = configuration.GetSection("ActiveDirectory");
            services.Configure<ActiveDirectory>(section);

            return services;
        }
    }
}