using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Interface denoting plug-in attributes that are displayed throughout 
    /// the editing interface.
    /// 表示贯穿始终的插件属性的接口
    ///编辑界面
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets a configuration page URL
        /// 获取配置页URL
        /// </summary>
        string GetConfigurationPageUrl();

        /// <summary>
        /// Gets or sets the plugin descriptor
        /// 获取或设置插件描述符
        /// </summary>
        PluginDescriptor PluginDescriptor { get; set; }

        /// <summary>
        /// Install plugin
        /// 安装插件
        /// </summary>
        void Install();

        /// <summary>
        /// Uninstall plugin
        /// 卸载插件
        /// </summary>
        void Uninstall();

        /// <summary>
        /// Prepare plugin to the uninstallation
        /// 准备插件卸载
        /// </summary>
        void PreparePluginToUninstall();
    }
}
