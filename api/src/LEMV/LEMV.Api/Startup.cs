using CloudinaryDotNet;
using LEMV.Api.Configurations;
using LEMV.Application;
using LEMV.Application.Services;
using LEMV.Application.Services.Cloudinary;
using LEMV.Application.Services.Interfaces;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LEMV.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(p =>
            {
                return new LiteDatabase(Configuration.GetConnectionString("LiteDB"));
            });

            var cloudinarySettings = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();

            services.AddScoped(p =>
            {
                return new Account(
                cloudinarySettings.CloudName,
                cloudinarySettings.ApiKey,
                cloudinarySettings.ApiSecret
            );
            });

            services.AddScoped<ICloudinaryService, CloudinaryService>();

            services.AddSwaggerGen();

            services.AddDependencyInjection(Configuration)
                    .AddAutoMapper(typeof(AssemblyReference).Assembly)
                    .AddIdentityJwt()
                    .AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("localhost", b => b.AllowAnyOrigin()
                                                     .AllowAnyMethod()
                                                     .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("localhost");

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}