using System;
using System.Reflection;
using JLRP.Data;
using JLRP.Data.IRepositories;
using JLRP.Data.Repositories;
using JLRP.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JLRP.API
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
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<TemplateDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30),
                            null);
                    });
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",new OpenApiInfo{Title = "JLRP sample CQRS", Version = "v1"});
                s.DescribeAllParametersInCamelCase();
            });

            //Add DIs
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ICustomerDxos, CustomerDxos>();
            services.AddMediatR(typeof(GetUserHandler).GetTypeInfo().Assembly);

            services.AddLogging();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "JLRP sample CQRS API V1"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
