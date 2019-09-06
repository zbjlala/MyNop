using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring services and middleware on application startup
    /// 表示在应用程序启动时配置服务和中间件的对象
    /// </summary>
    public interface INopStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// 添加和配置任何中间件
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        /// <summary>
        /// Configure the using of added middleware
        /// 配置已添加中间件的使用
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        void Configure(IApplicationBuilder application);

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// 获取此启动配置实现的顺序
        /// </summary>
        int Order { get; }
    }
}
