using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer.Repositories;
using DataLayer.REpositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTlayer
{
    public class Startup
    {
        private string connectionString = @"Data Source=NB21-6CDPYD3\SQLEXPRESS;Initial Catalog=AdresbeheerVrijdag;Integrated Security=True";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IGemeenteRepository>(x => new GemeenteRepositoryADO(connectionString));
            services.AddSingleton<IStraatRepository>(x => new StraatRepositoryADO(connectionString));
            services.AddSingleton<IAdresRepository>(x => new AdresRepositoryADO(connectionString));
            services.AddSingleton<GemeenteService>();
            services.AddSingleton<StraatService>();
            services.AddSingleton<AdresService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RESTlayer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RESTlayer v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
