using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents startup hosting configuration parameters
    /// 表示启动主机配置参数
    /// </summary>
    public partial class HostingConfig
    {
        /// <summary>
        /// Gets or sets custom forwarded HTTP header (e.g. CF-Connecting-IP, X-FORWARDED-PROTO, etc)
        /// 获取或设置自定义转发的HTTP头(例如CF-Connecting-IP、x - forwarding - proto等)
        /// </summary>
        public string ForwardedHttpHeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use HTTP_CLUSTER_HTTPS
        /// 获取或设置一个值，该值指示是否使用HTTP_CLUSTER_HTTPS
        /// </summary>
        public bool UseHttpClusterHttps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use HTTP_X_FORWARDED_PROTO
        /// 获取或设置一个值，该值指示是否使用http_x_forwarding _proto
        /// </summary>
        public bool UseHttpXForwardedProto { get; set; }
    }
}
