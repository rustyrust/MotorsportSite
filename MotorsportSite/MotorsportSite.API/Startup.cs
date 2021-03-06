using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MotorsportSite.API.Services;
using MotorsportSite.API.Services.Interfaces;
using MotorsportSite.DataLevel.DataAccess;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using MotorsportSite.DataLevel.Drivers.DataAccess;
using MotorsportSite.DataLevel.Drivers.Interfaces;
using MotorsportSite.DataLevel.Services;
using MotorsportSite.DataLevel.Services.Interfaces;
using MotorsportSite.DataLevel.TeamPrinciples.DataAccess;
using MotorsportSite.DataLevel.TeamPrinciples.Interfaces;

namespace MotorsportSite.API
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotorsportSite Api", Version = "v1" });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //add a new one of these for every interface
            services.AddTransient<IDataReader, DataReader>();
            services.AddTransient<IConnectionProvider, ConnectionProvider>();
            services.AddTransient<IDataWriter, DataWriter>();
            services.AddTransient<ITeamPrincipleDataReader, TeamPrincipleDataReader>();
            services.AddTransient<ITeamPrincipleDataWriter, TeamPrincipleDataWriter>();
            services.AddTransient<IDriverReader, DriverReader>();
            services.AddTransient<ICalculate, Calculate>();
            services.AddTransient<IDriverInformationService, DriverInformationService>();
            services.AddTransient<IDriverQualifyingReader, DriverQualifyingReader>();
            services.AddTransient<IDriversChampionshipReader, DriversChampionshipReader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotorsportSite Api");
            });

            app.UseHttpsRedirection();
                     
            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
