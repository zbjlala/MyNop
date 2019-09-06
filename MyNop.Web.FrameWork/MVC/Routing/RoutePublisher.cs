using Microsoft.AspNetCore.Routing;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNop.Web.FrameWork.MVC.Routing
{
    /// <summary>
    /// Represents implementation of route publisher
    /// 表示路由发布程序的实现
    /// </summary>
    public class RoutePublisher : IRoutePublisher
    {
        #region Fields

        /// <summary>
        /// Type finder
        /// </summary>
        protected readonly ITypeFinder _typeFinder;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="typeFinder">Type finder</param>
        public RoutePublisher(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register routes
        /// 注册的路线
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public virtual void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //find route providers provided by other assemblies
            //查找由其他程序集提供的路由提供程序
            var routeProviders = _typeFinder.FindClassesOfType<IRouteProvider>();

            //create and sort instances of route providers
            //创建和排序路由提供程序的实例
            var instances = routeProviders
                .Select(routeProvider => (IRouteProvider)Activator.CreateInstance(routeProvider))
                .OrderByDescending(routeProvider => routeProvider.Priority);

            //register all provided routes
            foreach (var routeProvider in instances)
                routeProvider.RegisterRoutes(routeBuilder);
        }

        #endregion
    }
}
