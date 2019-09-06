using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Nop.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyNop.Web.FrameWork.MVC.Routing
{
    /// <summary>
    /// Represents custom overridden redirect result executor
    /// 表示自定义重写的重定向结果执行程序
    /// </summary>
    public class NopRedirectResultExecutor : RedirectResultExecutor
    {
        #region Fields

        private readonly SecuritySettings _securitySettings;

        #endregion

        #region Ctor

        public NopRedirectResultExecutor(ILoggerFactory loggerFactory,
            IUrlHelperFactory urlHelperFactory,
            SecuritySettings securitySettings) : base(loggerFactory, urlHelperFactory)
        {
            _securitySettings = securitySettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute passed redirect result
        /// 执行通过的重定向结果
        /// </summary>
        /// <param name="context">Action context</param>
        /// <param name="result">Redirect result</param>
        /// <returns>Task that represents the asynchronous operation</returns>
        public override Task ExecuteAsync(ActionContext context, RedirectResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            if (_securitySettings.AllowNonAsciiCharactersInHeaders)
            {
                //passed redirect URL may contain non-ASCII characters, that are not allowed now (see https://github.com/aspnet/KestrelHttpServer/issues/1144)
                //so we force to encode this URL before processing
                result.Url = Uri.EscapeUriString(WebUtility.UrlDecode(result.Url));
            }

            return base.ExecuteAsync(context, result);
        }

        #endregion
    }
}
