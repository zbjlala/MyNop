using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.External
{
    /// <summary>
    /// Interface to register (configure) an external authentication service (plugin)
    /// 注册(配置)外部身份验证服务的接口(插件)
    /// </summary>
    public interface IExternalAuthenticationRegistrar
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">Authentication builder</param>
        void Configure(AuthenticationBuilder builder);
    }
}
