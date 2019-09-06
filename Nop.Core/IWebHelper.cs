using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core
{
    /// <summary>
    /// Represents a web helper
    /// 表示一个web助手
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// Get URL referrer if exists
        /// 获取URL引用(如果存在)
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// Get IP address from HTTP context
        /// 从HTTP上下文获取IP地址
        /// </summary>
        /// <returns>String of IP address</returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// Gets this page URL
        /// 获取此页面URL
        /// </summary>
        /// <param name="includeQueryString">Value indicating whether to include query strings</param>
        /// <param name="useSsl">Value indicating whether to get SSL secured page URL. Pass null to determine automatically</param>
        /// <param name="lowercaseUrl">Value indicating whether to lowercase URL</param>
        /// <returns>Page URL</returns>
        string GetThisPageUrl(bool includeQueryString, bool? useSsl = null, bool lowercaseUrl = false);

        /// <summary>
        /// Gets a value indicating whether current connection is secured
        /// 获取一个值，该值指示当前连接是否安全
        /// </summary>
        /// <returns>True if it's secured, otherwise false</returns>
        bool IsCurrentConnectionSecured();

        /// <summary>
        /// Gets store host location
        /// 获取存储主机位置
        /// </summary>
        /// <param name="useSsl">Whether to get SSL secured URL</param>
        /// <returns>Store host location</returns>
        string GetStoreHost(bool useSsl);

        /// <summary>
        /// Gets store location
        /// 获取存储位置
        /// </summary>
        /// <param name="useSsl">Whether to get SSL secured URL; pass null to determine automatically</param>
        /// <returns>Store location</returns>
        string GetStoreLocation(bool? useSsl = null);

        /// <summary>
        /// Returns true if the requested resource is one of the typical resources that needn't be processed by the CMS engine.
        /// 如果请求的资源是CMS引擎不需要处理的典型资源之一，则返回true。
        /// </summary>
        /// <returns>True if the request targets a static resource file.</returns>
        bool IsStaticResource();

        /// <summary>
        /// Modify query string of the URL
        /// 修改URL的查询字符串
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="key">Query parameter key to add</param>
        /// <param name="values">Query parameter values to add</param>
        /// <returns>New URL with passed query parameter</returns>
        string ModifyQueryString(string url, string key, params string[] values);

        /// <summary>
        /// Remove query parameter from the URL
        /// 从URL中删除查询参数
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="key">Query parameter key to remove</param>
        /// <param name="value">Query parameter value to remove; pass null to remove all query parameters with the specified key</param>
        /// <returns>New URL without passed query parameter</returns>
        string RemoveQueryString(string url, string key, string value = null);

        /// <summary>
        /// Gets query string value by name
        /// 按名称获取查询字符串值
        /// </summary>
        /// <typeparam name="T">Returned value type</typeparam>
        /// <param name="name">Query parameter name</param>
        /// <returns>Query string value</returns>
        T QueryString<T>(string name);

        /// <summary>
        /// Restart application domain
        /// 重启应用程序域
        /// </summary>
        /// <param name="makeRedirect">A value indicating whether we should made redirection after restart</param>
        void RestartAppDomain(bool makeRedirect = false);

        /// <summary>
        /// Gets a value that indicates whether the client is being redirected to a new location
        /// 获取一个值，该值指示是否将客户端重定向到新位置
        /// </summary>
        bool IsRequestBeingRedirected { get; }

        /// <summary>
        /// Gets or sets a value that indicates whether the client is being redirected to a new location using POST
        /// 获取或设置一个值，该值指示是否使用POST将客户端重定向到新位置
        /// </summary>
        bool IsPostBeingDone { get; set; }

        /// <summary>
        /// Gets current HTTP request protocol
        /// 获取当前HTTP请求协议
        /// </summary>
        string CurrentRequestProtocol { get; }

        /// <summary>
        /// Gets whether the specified HTTP request URI references the local host.
        /// 获取指定的HTTP请求URI是否引用本地主机。
        /// </summary>
        /// <param name="req">HTTP request</param>
        /// <returns>True, if HTTP request URI references to the local host</returns>
        bool IsLocalRequest(HttpRequest req);

        /// <summary>
        /// Get the raw path and full query of request
        /// 获取请求的原始路径和完整查询
        /// </summary>
        /// <param name="request">HTTP request</param>
        /// <returns>Raw URL</returns>
        string GetRawUrl(HttpRequest request);

        /// <summary>
        /// Gets whether the request is made with AJAX
        /// 获取请求是否使用AJAX发出
        /// </summary>
        /// <param name="request">HTTP request</param>
        /// <returns>Result</returns>
        bool IsAjaxRequest(HttpRequest request);
    }
}
