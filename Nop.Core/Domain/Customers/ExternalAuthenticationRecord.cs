using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents an external authentication record
    /// 表示外部身份验证记录
    /// </summary>
    public partial class ExternalAuthenticationRecord : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// 获取或设置客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the external email
        /// 获取或设置外部电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the external identifier
        /// 获取或设置外部标识符
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the external display identifier
        /// 获取或设置外部显示标识符
        /// </summary>
        public string ExternalDisplayIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the OAuthToken
        /// 获取或设置OAuthToken
        /// </summary>
        public string OAuthToken { get; set; }

        /// <summary>
        /// Gets or sets the OAuthAccessToken
        /// 获取或设置OAuthAccessToken
        /// </summary>
        public string OAuthAccessToken { get; set; }

        /// <summary>
        /// Gets or sets the provider
        /// 获取或设置提供程序
        /// </summary>
        public string ProviderSystemName { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
