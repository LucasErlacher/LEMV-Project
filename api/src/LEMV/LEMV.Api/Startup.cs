using LEMV.Api.Configurations;
using LEMV.Application;
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
            services.AddTransient(p =>
            {
                return new LiteDatabase(Configuration.GetConnectionString("LiteDB"));
            });

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