using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNop.Web.FrameWork.Infrastructure.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace MyNop
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

        }

        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                // c.SwaggerDoc("v1", new Info { Title = "DemoAPI", Version = "v1" });
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "lucky_app - V1.0",
                        Version = "v1",
                        Description = "³õÊ¼°æ¿ò¼Ü1.0",
                        TermsOfService = "Knock yourself out",
                        Contact = new Contact { Name = "zbj test", Email = "zhangbaoj@chanjet.com" },
                        License = new License { Name = "chanjet.com", Url = "http://www.chanjet.com/" }
                    });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyNop.xml");
                c.IncludeXmlComments(filePath);
            });

            return services.ConfigureApplicationServices(_configuration, _hostingEnvironment);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "lucky_app V1.0"); });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                                     name: "default",
                                     template: "swagger");
            });
            app.ConfigureRequestPipeline();
        }
    }
}
