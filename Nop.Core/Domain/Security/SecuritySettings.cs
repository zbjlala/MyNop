using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// Security settings
    /// 安全设置
    /// </summary>
    public class SecuritySettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether all pages will be forced to use SSL (no matter of a specified [HttpsRequirementAttribute] attribute)
        /// 获取或设置一个值，该值指示是否将强制所有页面使用SSL(无论指定的[HttpsRequirementAttribute]属性是什么)
        /// </summary>
        public bool ForceSslForAllPages { get; set; }

        /// <summary>
        /// Gets or sets an encryption key
        /// 获取或设置加密密钥
        /// </summary>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets a list of admin area allowed IP addresses
        /// 获取或设置允许IP地址的管理区域列表
        /// </summary>
        public List<string> AdminAreaAllowedIpAddresses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether XSRF protection for admin area should be enabled
        /// 获取或设置一个值，该值指示是否应启用管理区域的XSRF保护
        /// </summary>
        public bool EnableXsrfProtectionForAdminArea { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether XSRF protection for public store should be enabled
        /// 获取或设置一个值，该值指示是否应启用公共存储的XSRF保护
        /// </summary>
        public bool EnableXsrfProtectionForPublicStore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether honeypot is enabled on the registration page
        /// 获取或设置一个值，该值指示是否在注册页上启用蜜罐
        /// </summary>
        public bool HoneypotEnabled { get; set; }

        /// <summary>
        /// Gets or sets a honeypot input name
        /// 获取或设置蜜罐输入名称
        /// </summary>
        public string HoneypotInputName { get; set; }

        /// <summary>
        /// Get or set the blacklist of static file extension for plugin directories
        /// 获取或设置插件目录的静态文件扩展名的黑名单
        /// </summary>
        public string PluginStaticFileExtensionsBlacklist { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow non-ASCII characters in headers
        /// 获取或设置一个值，该值指示是否在标头中允许非ascii字符
        /// </summary>
        public bool AllowNonAsciiCharactersInHeaders { get; set; }
    }
}
