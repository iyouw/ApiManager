using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiManager.Api.Application.Queries;
using ApiManager.Api.Application.Services;
using ApiManager.Core.Repositories;
using ApiManager.Infra.CodeGenerator;
using ApiManager.Infra.Dal;
using ApiManager.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiManager.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiManager.Api", Version = "v1" });
            });

            services.AddCors( options =>
            {
                options.AddDefaultPolicy(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDAL(Configuration.GetSection("Dal"));
            services.AddRepository();

            services.AddApplicationServices();

            services.AddAppQuery();
            services.AddCodeEngine();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiManager.Api v1"));
            }

            // app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
