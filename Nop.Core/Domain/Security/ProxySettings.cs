using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// Proxy settings
    /// </summary>
    public partial class ProxySettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether we should use proxy connection
        /// 获取或设置一个值，该值指示是否应使用代理连接
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the address of the proxy server
        /// 获取或设置代理服务器的地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the port of the proxy server
        /// 获取或设置代理服务器的端口
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets the username for proxy connection
        /// 获取或设置代理连接的用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for proxy connection
        /// 获取或设置代理连接的密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to bypass the proxy server for local addresses
        /// 获取或设置一个值，该值指示是否为本地地址绕过代理服务器
        /// </summary>
        public bool BypassOnLocal { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the handler sends an Authorization header with the request
        /// 获取或设置一个值，该值指示是否为本地地址绕过代理服务器
        /// </summary>
        public bool PreAuthenticate { get; set; }
    }
}
