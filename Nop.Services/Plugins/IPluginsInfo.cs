using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Represents an information about plugins
    /// 表示有关插件的信息
    /// </summary>
    public interface IPluginsInfo
    {
        /// <summary>
        /// Save plugins info to the file
        /// 将插件信息保存到文件中
        /// </summary>
        void Save();

        /// <summary>
        /// Get plugins info
        /// 获取插件信息
        /// </summary>
        /// <returns>True if data are loaded, otherwise False</returns>
        bool LoadPluginInfo();

        /// <summary>
        /// Create copy from another instance of IPluginsInfo interface
        /// 拷贝IPluginsInfo接口的另一个实例创建副本
        /// </summary>
        /// <param name="pluginsInfo">Plugins info</param>
        void CopyFrom(IPluginsInfo pluginsInfo);

        /// <summary>
        /// Gets or sets the list of all installed plugin names
        /// 获取或设置所有已安装插件名称的列表
        /// </summary>
        IList<string> InstalledPluginNames { get; set; }

        /// <summary>
        /// Gets or sets the list of plugin names which will be uninstalled
        /// 获取或设置将卸载的插件名称列表
        /// </summary>
        IList<string> PluginNamesToUninstall { get; set; }

        /// <summary>
        /// Gets or sets the list of plugin names which will be deleted
        /// 获取或设置将被删除的插件名称列表
        /// </summary>
        IList<string> PluginNamesToDelete { get; set; }

        /// <summary>
        /// Gets or sets the list of plugin names which will be installed
        /// 获取或设置将安装的插件名称列表
        /// </summary>
        IList<(string SystemName, Guid? CustomerGuid)> PluginNamesToInstall { get; set; }

        /// <summary>
        /// Gets or sets the list of assembly loaded collisions
        /// 获取或设置加载的程序集冲突列表
        /// </summary>
        IList<PluginLoadedAssemblyInfo> AssemblyLoadedCollision { get; set; }

        /// <summary>
        /// Gets or sets a collection of plugin descriptors of all deployed plugins
        /// </summary>
        IEnumerable<PluginDescriptor> PluginDescriptors { get; set; }

        /// <summary>
        /// Gets or sets the list of plugin names which are not compatible with the current version
        /// </summary>
        IList<string> IncompatiblePlugins { get; set; }
    }
}
