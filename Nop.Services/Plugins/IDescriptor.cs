using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Represents descriptor of the application extension (plugin or theme)
    /// 表示应用程序扩展(插件或主题)的描述符
    /// </summary>
    public interface IDescriptor
    {
        /// <summary>
        /// Gets or sets the system name
        /// 获取或设置系统名称
        /// </summary>
        string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the friendly name
        /// 获取或设置友好名称
        /// </summary>
        string FriendlyName { get; set; }
    }
}
