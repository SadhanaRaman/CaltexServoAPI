using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaltexCustomerAPI.Models;
using CaltexCustomerAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CaltexCustomerAPI
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
            services.AddMvc();
            services.AddScoped<IStoreService, StoreService>();

            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("CaltexPISpec",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Caltex API",
                        Version = "1",
                        Description = "Sadhana Caltex API",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "Sadhu4590@gmail.com",
                            Name = "Sadhana Kalyana Raman",
                            Url = new Uri("http://test.com")
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "Sadhana Kalyana Raman",
                            Url = new Uri("http://test.com")
                        }
                    });

                //var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                //options.IncludeXmlComments(xmlCommentsFullPath);
            });

            //services.AddDbContext<sampleContext>(options => options.UseSqlite("Data Source=MSI"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
               //app.UseExceptionHandler("/api/error");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {

                options.SwaggerEndpoint("swagger/CaltexPISpec/swagger.json",
                   "Caltex API");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
              
                endpoints.MapControllers();
            });

        }
    }
}
