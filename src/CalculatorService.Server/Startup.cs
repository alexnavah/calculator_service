using CalculatorService.Domain.Models.Error;
using CalculatorService.Server.Attributes;
using CalculatorService.Server.Configuration;
using CalculatorService.Server.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace CalculatorService.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();
            services.ConfigureDependencyInjection();

            services.AddSwaggerGen(s =>
            {
                s.OperationFilter<EviTrackingSwaggerAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<LoggerMiddleware>();

            app.UseExceptionHandler(exceptionHandler =>
            {
                exceptionHandler.Run(async context =>
                {
                    /***
                     * Return a custom internal server error instead of whole Exception with Stacktrace, etc...
                     */
                    if (context.Response.StatusCode.Equals(StatusCodes.Status500InternalServerError))
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(ErrorResult.CreateInternalError()));
                    }
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}
