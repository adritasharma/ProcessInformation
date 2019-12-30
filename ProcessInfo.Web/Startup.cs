using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Implementations;
using ProcessInfo.Repository.Interfaces;
using ProcessInfo.Service.Implementations;
using ProcessInfo.Service.Interfaces;
using AutoMapper;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ProcessInfo.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

          //  services.AddDbContext<IndigoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IndigoContext")).EnableSensitiveDataLogging());
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IApplicationRepository), typeof(ApplicationRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            services.AddScoped(typeof(IApplicationService), typeof(ApplicationService));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            services.AddDbContext<ProcessInfoDbContext>(options =>
                        options.UseMySql(Configuration.GetConnectionString("processinfo")));
            services.AddAutoMapper(typeof(Startup));

            var datatableOptions = new Options()
                                    .EnableRequestAdditionalParameters()
                                    .EnableResponseAdditionalParameters();

            var dataTableBinder = new ModelBinder();
            dataTableBinder.ParseAdditionalParameters = Parser;
            services.RegisterDataTables(datatableOptions, dataTableBinder);


            //  services.AddScoped(typeof(IGenericRepository), typeof(GenericRepository));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private static IDictionary<string, object> Parser(ModelBindingContext arg)
        {
            var res = new Dictionary<string, object>();
            var httpMethod = arg.HttpContext.Request.Method;

            var keys = (httpMethod.ToLower() == "post") ? arg.HttpContext.Request.Form.Keys : arg.HttpContext.Request.Query.Keys;
            var modelKeys = keys.Where(m => !m.StartsWith("columns") && !m.StartsWith("order") && !m.StartsWith("search") && m != "draw" && m != "start" && m != "length" && m != "_");
            foreach (string key in modelKeys)
            {
                var value = arg.ValueProvider.GetValue(key).FirstValue;
                if (value.Length > 0)
                    res.Add(key, value);
            }
            return res;
        }
    }
}
