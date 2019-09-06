using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Represents a plugin service
    /// 表示插件服务
    /// </summary>
    public partial interface IPluginService
    {
        /// <summary>
        /// Get plugin descriptors
        /// 表示插件服务
        /// </summary>
        /// <typeparam name="TPlugin">The type of plugins to get</typeparam>
        /// <param name="loadMode">Filter by load plugins mode</param>
        /// <param name="customer">Filter by  customer; pass null to load all records</param>
        /// <param name="storeId">Filter by store; pass 0 to load all records</param>
        /// <param name="group">Filter by plugin group; pass null to load all records</param>
        /// <param name="dependsOnSystemName">System name of the plugin to define dependencies</param>
        /// <returns>Plugin descriptors</returns>
        IEnumerable<PluginDescriptor> GetPluginDescriptors<TPlugin>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null, string dependsOnSystemName = "") where TPlugin : class, IPlugin;

        /// <summary>
        /// Get a plugin descriptor by the system name
        /// 根据系统名称获取插件描述符
        /// </summary>
        /// <typeparam name="TPlugin">The type of plugin to get</typeparam>
        /// <param name="systemName">Plugin system name</param>
        /// <param name="loadMode">Load plugins mode</param>
        /// <param name="customer">Filter by  customer; pass null to load all records</param>
        /// <param name="storeId">Filter by store; pass 0 to load all records</param>
        /// <param name="group">Filter by plugin group; pass null to load all records</param>
        /// <returns>>Plugin descriptor</returns>
        PluginDescriptor GetPluginDescriptorBySystemName<TPlugin>(string systemName,
            LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) where TPlugin : class, IPlugin;

        /// <summary>
        /// Get plugins
        /// </summary>
        /// <typeparam name="TPlugin">The type of plugins to get</typeparam>
        /// <param name="loadMode">Filter by load plugins mode</param>
        /// <param name="customer">Filter by  customer; pass null to load all records</param>
        /// <param name="storeId">Filter by store; pass 0 to load all records</param>
        /// <param name="group">Filter by plugin group; pass null to load all records</param>
        /// <returns>Plugins</returns>
        IEnumerable<TPlugin> GetPlugins<TPlugin>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) where TPlugin : class, IPlugin;

        /// <summary>
        /// Find a plugin by the type which is located into the same assembly as a plugin
        /// 按与插件位于同一程序集中的类型查找插件
        /// </summary>
        /// <param name="typeInAssembly">Type</param>
        /// <returns>Plugin</returns>
        IPlugin FindPluginByTypeInAssembly(Type typeInAssembly);

        /// <summary>
        /// Get plugin logo URL
        /// 获取插件徽标URL
        /// </summary>
        /// <param name="pluginDescriptor">Plugin descriptor</param>
        /// <returns>Logo URL</returns>
        string GetPluginLogoUrl(PluginDescriptor pluginDescriptor);

        /// <summary>
        /// Prepare plugin to the installation
        /// 准备安装插件
        /// </summary>
        /// <param name="systemName">Plugin system name</param>
        /// <param name="customer">Customer</param>
        /// <param name="checkDependencies">Specifies whether to check plugin dependencies</param>
        void PreparePluginToInstall(string systemName, Customer customer = null, bool checkDependencies = true);

        /// <summary>
        /// Prepare plugin to the uninstallation
        /// 准备插件卸载
        /// </summary>
        /// <param name="systemName">Plugin system name</param>
        void PreparePluginToUninstall(string systemName);

        /// <summary>
        /// Prepare plugin to the removing
        /// 准备插件删除
        /// </summary>
        /// <param name="systemName">Plugin system name</param>
        void PreparePluginToDelete(string systemName);

        /// <summary>
        /// Reset changes
        /// 重置更改
        /// </summary>
        void ResetChanges();

        /// <summary>
        /// Clear installed plugins list
        /// 清除已安装插件列表
        /// </summary>
        void ClearInstalledPluginsList();

        /// <summary>
        /// Install plugins
        /// 安装插件
        /// </summary>
        void InstallPlugins();

        /// <summary>
        /// Uninstall plugins
        /// 卸载插件
        /// </summary>
        void UninstallPlugins();

        /// <summary>
        /// Delete plugins
        /// 删除插件
        /// </summary>
        void DeletePlugins();

        /// <summary>
        /// Check whether application restart is required to apply changes to plugins
        /// 检查是否需要重新启动应用程序才能将更改应用于插件
        /// </summary>
        /// <returns>Result of check</returns>
        bool IsRestartRequired();

        /// <summary>
        /// Get names of incompatible plugins
        /// 获取不兼容插件的名称
        /// </summary>
        /// <returns>List of plugin names</returns>
        IList<string> GetIncompatiblePlugins();

        /// <summary>
        /// Get all assembly loaded collisions
        /// 获取所有加载的程序集冲突
        /// </summary>
        /// <returns>List of plugin loaded assembly info</returns>
        IList<PluginLoadedAssemblyInfo> GetAssemblyCollisions();
    }
}
