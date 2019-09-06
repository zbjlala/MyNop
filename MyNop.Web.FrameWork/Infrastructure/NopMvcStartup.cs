using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNop.Web.FrameWork.Infrastructure.Extensions;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNop.Web.FrameWork.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// 表示在应用程序启动时配置MVC的对象
    /// </summary>
    public class NopMvcStartup : INopStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// 添加和配置任何中间件
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ////add MiniProfiler services
            //services.AddNopMiniProfiler();

            ////add WebMarkupMin services to the services container
            //services.AddNopWebMarkupMin();

            //add and configure MVC feature
            services.AddNopMvc();

            //add custom redirect result executor
            services.AddNopRedirectResultExecutor();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //use MiniProfiler
            application.UseMiniProfiler();

            //use WebMarkupMin
            application.UseNopWebMarkupMin();

            //MVC routing
            application.UseNopMvc();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 1000; //MVC should be loaded last
    }
}
