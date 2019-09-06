using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Http
{
    /// <summary>
    /// Represents default values related to HTTP features
    /// 表示与HTTP特性相关的默认值
    /// </summary>
    public static partial class NopHttpDefaults
    {
        /// <summary>
        /// Gets the name of the default HTTP client
        /// 获取默认HTTP客户机的名称
        /// </summary>
        public static string DefaultHttpClient => "default";

        /// <summary>
        /// Gets the name of a request item that stores the value that indicates whether the client is being redirected to a new location using POST
        /// 获取一个请求项的名称，该请求项存储指示是否使用POST将客户端重定向到新位置的值
        /// </summary>
        public static string IsPostBeingDoneRequestItem => "nop.IsPOSTBeingDone";

        /// <summary>
        /// Gets the name of HTTP_CLUSTER_HTTPS header
        /// 获取HTTP_CLUSTER_HTTPS请求头名字
        /// </summary>
        public static string HttpClusterHttpsHeader => "HTTP_CLUSTER_HTTPS";

        /// <summary>
        /// Gets the name of HTTP_X_FORWARDED_PROTO header
        /// 获取HTTP_X_FORWARDED_PROTO请求头名字
        /// </summary>
        public static string HttpXForwardedProtoHeader => "X-Forwarded-Proto";

        /// <summary>
        /// Gets the name of X-FORWARDED-FOR header
        /// 获取X-FORWARDED-FOR请求头名字
        /// </summary>
        public static string XForwardedForHeader => "X-FORWARDED-FOR";
    }
}
