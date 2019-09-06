using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Authentication
{
    /// <summary>
    /// Represents default values related to authentication services
    /// 表示与身份验证服务相关的默认值
    /// </summary>
    public static partial class NopAuthenticationDefaults
    {
        /// <summary>
        /// The default value used for authentication scheme
        /// 用于身份验证方案的默认值
        /// </summary>
        public static string AuthenticationScheme => "Authentication";

        /// <summary>
        /// The default value used for external authentication scheme
        /// 用于外部身份验证方案的默认值
        /// </summary>
        public static string ExternalAuthenticationScheme => "ExternalAuthentication";

        /// <summary>
        /// The issuer that should be used for any claims that are created
        /// 应用于创建的任何索赔的发行者
        /// </summary>
        public static string ClaimsIssuer => "nopCommerce";

        /// <summary>
        /// The default value for the login path
        /// 登录路径的默认值
        /// </summary>
        public static PathString LoginPath => new PathString("/login");

        /// <summary>
        /// The default value used for the logout path
        /// 用于注销路径的默认值
        /// </summary>
        public static PathString LogoutPath => new PathString("/logout");

        /// <summary>
        /// The default value for the access denied path
        /// 访问拒绝路径的默认值
        /// </summary>
        public static PathString AccessDeniedPath => new PathString("/page-not-found");

        /// <summary>
        /// The default value of the return URL parameter
        /// 返回URL参数的默认值
        /// </summary>
        public static string ReturnUrlParameter => string.Empty;

        /// <summary>
        /// Gets a key to store external authentication errors to session
        /// 获取一个密钥，以将外部身份验证错误存储到会话
        /// </summary>
        public static string ExternalAuthenticationErrorsSessionKey => "nop.externalauth.errors";
    }
}
