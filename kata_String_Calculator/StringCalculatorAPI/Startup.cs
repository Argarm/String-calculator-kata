using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace StringCalculatorAPI
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
            
            services.AddHealthChecks().AddCheck<HealthCheck>("Health_Check_Example");
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic healthcheck", "https://localhost:5001/health");
            });

            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddApiVersioning(o => o.ReportApiVersions = true);

            services.AddApplicationInsightsTelemetry(Configuration["ApplicationInsights:InstrumentationKey"]);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                
                c.ResolveConflictingActions(apiDescription => apiDescription.First());
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0",
                    Title = "String Calculator API",
                    Description = "API que suma una serie de numeros pasados",
                    TermsOfService = "#Version 1.0",
                    License = new License
                    {
                        Name = "MIT",
                        Url = "https://es.wikipedia.org/wiki/Licencia_MIT"
                    },
                    Contact = new Contact
                    {
                        Name = "Aarón García",
                        Email = "aargarcia@domingoalonsogroup.com",
                        Url = "github.com/Argarm"
                    }
                });
                c.SwaggerDoc("v2", new Info
                {
                    Version = "v2.0",
                    Title = "String Calculator API",
                    Description = "API que suma una serie de numeros pasados",
                    TermsOfService = "#Version 2.0",
                    License = new License
                    {
                        Name = "MIT",
                        Url = "https://es.wikipedia.org/wiki/Licencia_MIT"
                    },
                    Contact = new Contact
                    {
                        Name = "Aarón García",
                        Email = "aargarcia@domingoalonsogroup.com",
                        Url = "github.com/Argarm"
                    }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)) + ".xml";
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

            });


            app.UseHealthChecksUI(config => config.UIPath = "/health-ui");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "v2.0");  
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }

}