using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddScoped<EFReCapContext>();

            services.AddScoped<ICarEngine, CarEngine>();
            services.AddScoped<ICarRepository>(x =>
                new EFCarRepository(x.GetRequiredService<EFReCapContext>())
            );

            services.AddScoped<IBrandEngine, BrandEngine>();
            services.AddScoped<IBrandRepository>(x =>
                new EFBrandRepository(x.GetRequiredService<EFReCapContext>())
            );

            services.AddScoped<IColorEngine, ColorEngine>();
            services.AddScoped<IColorRepository>(x =>
                new EFColorRepository(x.GetRequiredService<EFReCapContext>())
            );

            services.AddScoped<ICustomerEngine, CustomerEngine>();
            services.AddScoped<ICustomerRepository>(x =>
                new EFCustomerRepository(x.GetRequiredService<EFReCapContext>())
            );

            services.AddScoped<IRentalEngine, RentalEngine>();
            services.AddScoped<IRentalRepository>(x =>
                new EFRentalRepository(x.GetRequiredService<EFReCapContext>())
            );

            services.AddScoped<IUserEngine, UserEngine>();
            services.AddScoped<IUserRepository>(x =>
                new EFUserRepository(x.GetRequiredService<EFReCapContext>())
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
