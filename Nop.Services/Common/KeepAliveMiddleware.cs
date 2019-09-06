using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    /// <summary>
    /// Represents middleware that checks whether request is for keep alive
    /// 表示检查请求是否为保持活动的中间件
    /// </summary>
    public class KeepAliveMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;

        #endregion

        #region Ctor

        public KeepAliveMiddleware(RequestDelegate next)
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
            if (DataSettingsManager.DatabaseIsInstalled)
            {
                //keep alive page requested (we ignore it to prevent creating a guest customer records)
                //保持所请求页面的活动状态(为了防止创建客户记录，我们忽略它)
                var keepAliveUrl = $"{webHelper.GetStoreLocation()}{NopCommonDefaults.KeepAlivePath}";
                if (webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
                    return;
            }

            //or call the next middleware in the request pipeline
            await _next(context);
        }

        #endregion
    }
}
