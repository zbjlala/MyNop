using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Logging
{
    /// <summary>
    /// Represents a log record
    /// 表示日志记录
    /// </summary>
    public partial class Log : BaseEntity
    {
        /// <summary>
        /// Gets or sets the log level identifier
        /// 获取或设置日志级别标识符
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// Gets or sets the short message
        /// 获取或设置短消息
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// Gets or sets the full exception
        /// 获取或设置完整异常
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// 获取或设置IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// 获取或设置客户标识符
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the page URL
        /// 获取或设置页面URL
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// Gets or sets the referrer URL
        /// 获取或设置引用者URL
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the log level
        /// 获取或设置日志级别
        /// </summary>
        public LogLevel LogLevel
        {
            get => (LogLevel)LogLevelId;
            set => LogLevelId = (int)value;
        }

        /// <summary>
        /// Gets or sets the customer
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
