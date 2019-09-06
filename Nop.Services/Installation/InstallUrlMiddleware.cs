using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Installation
{
    /// <summary>
    /// Represents middleware that checks whether database is installed and redirects to installation URL in otherwise
    /// 表示检查数据库是否已安装并重定向到安装URL的中间件
    /// </summary>
    public class InstallUrlMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;

        #endregion

        #region Ctor

        public InstallUrlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke middleware actions
        /// </summary>
        /// <param name="context">HTTP context</param>
        /// <param name="webHelper">Web helper</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context, IWebHelper webHelper)
        {
            //whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
            {
                var installUrl = $"{webHelper.GetStoreLocation()}{NopInstallationDefaults.InstallPath}";
                if (!webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
                {
                    //redirect
                    context.Response.Redirect(installUrl);
                    return;
                }
            }

            //or call the next middleware in the request pipeline
            await _next(context);
        }

        #endregion
    }
}
