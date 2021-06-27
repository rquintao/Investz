using Investz.Data.Repositories;
using Investz.Database.Core;
using Investz.Interfaces;
using Investz.Services;
using Investz.Shared.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Investz
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
            //Register repositories
            RegisterRepositories(services);

            //Register services
            RegisterServices(services);

            //Register Context
            services.AddScoped<ICoreContext, CoreContext>();

            // Add Cors
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Investz", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investz v1"));
            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static void RegisterRepositories(IServiceCollection services) 
        {
            Assembly assemblyServices = Assembly.GetAssembly(typeof(UserRepository));
            Assembly assemblyInterfaces = Assembly.GetAssembly(typeof(IUserRepository));

            Assembly[] arr = { assemblyInterfaces };
            Assembly[] repArr = { assemblyServices };

            RegisterProcedure("Repository", arr, repArr, services, ServiceLifetime.Transient);
        }

        private static void RegisterServices(IServiceCollection services)
        {

            Assembly assemblyServices = Assembly.GetAssembly(typeof(UserService));
            Assembly assemblyInterfaces = Assembly.GetAssembly(typeof(IUserService));

            Assembly[] arr = { assemblyInterfaces };
            Assembly[] servArr = { assemblyServices };

            RegisterProcedure("Service", arr, servArr, services, ServiceLifetime.Transient);
        }

        private static void RegisterProcedure(string type, Assembly[] interfaceAssemby, Assembly[] servAssembly, IServiceCollection services, ServiceLifetime serviceLifetime) 
        {
            IEnumerable<Type> interfaces = interfaceAssemby.SelectMany(x => x.GetTypes().Where(z => z.IsInterface && z.Name.EndsWith(type)));

            foreach (Type t in interfaces)
            {

                IEnumerable<Type> serviceList = servAssembly.SelectMany(serv => serv.GetTypes().Where(x => x.GetInterfaces().Any(inter => inter.Name == t.Name)));

                foreach (Type st in serviceList)
                {
                    services.Add(new ServiceDescriptor(t, st, serviceLifetime));
                }
            }
        }
    }
}
