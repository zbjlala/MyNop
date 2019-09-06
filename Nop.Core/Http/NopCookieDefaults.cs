using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Http
{
    /// <summary>
    /// Represents default values related to cookies
    /// 表示与cookie相关的默认值
    /// </summary>
    public static partial class NopCookieDefaults
    {
        /// <summary>
        /// Gets the cookie name prefix
        /// 获取cookie名称前缀
        /// </summary>
        public static string Prefix => ".Nop";

        /// <summary>
        /// Gets a cookie name of the customer
        /// 获取客户的cookie名称
        /// </summary>
        public static string CustomerCookie => ".Customer";

        /// <summary>
        /// Gets a cookie name of the antiforgery
        /// 获取反伪造程序的cookie名称
        /// </summary>
        public static string AntiforgeryCookie => ".Antiforgery";

        /// <summary>
        /// Gets a cookie name of the session state
        /// 获取会话状态的cookie名称
        /// </summary>
        public static string SessionCookie => ".Session";

        /// <summary>
        /// Gets a cookie name of the temp data
        /// 获取临时数据的cookie名称
        /// </summary>
        public static string TempDataCookie => ".TempData";

        /// <summary>
        /// Gets a cookie name of the installation language
        /// 获取安装语言的cookie名称
        /// </summary>
        public static string InstallationLanguageCookie => ".InstallationLanguage";

        /// <summary>
        /// Gets a cookie name of the compared products
        /// 获取比较产品的cookie名称
        /// </summary>
        public static string ComparedProductsCookie => ".ComparedProducts";

        /// <summary>
        /// Gets a cookie name of the recently viewed products
        /// 获取最近查看的产品的cookie名称
        /// </summary>
        public static string RecentlyViewedProductsCookie => ".RecentlyViewedProducts";

        /// <summary>
        /// Gets a cookie name of the authentication
        /// 获取身份验证的cookie名称
        /// </summary>
        public static string AuthenticationCookie => ".Authentication";

        /// <summary>
        /// Gets a cookie name of the external authentication
        /// 获取外部身份验证的cookie名称
        /// </summary>
        public static string ExternalAuthenticationCookie => ".ExternalAuthentication";

        /// <summary>
        /// Gets a cookie name of the Eu Cookie Law Warning
        /// 获取欧盟cookie法律警告的cookie名称
        /// </summary>
        public static string IgnoreEuCookieLawWarning => ".IgnoreEuCookieLawWarning";

    }
}
