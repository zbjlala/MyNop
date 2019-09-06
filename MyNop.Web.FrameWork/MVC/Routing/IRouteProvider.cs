using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNop.Web.FrameWork.MVC.Routing
{
    /// <summary>
    /// Route provider
    /// 路线供应商
    /// </summary>
    public interface IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// 注册的路由
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        void RegisterRoutes(IRouteBuilder routeBuilder);

        /// <summary>
        /// Gets a priority of route provider
        /// 获取路由提供程序的优先级
        /// </summary>
        int Priority { get; }
    }
}
