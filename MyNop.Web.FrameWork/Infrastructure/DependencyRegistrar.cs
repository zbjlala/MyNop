using Autofac;
using MyNop.Web.FrameWork.MVC.Routing;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNop.Web.FrameWork.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// 依赖注册
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 0;

        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }
    }
}
