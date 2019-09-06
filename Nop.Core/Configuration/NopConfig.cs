using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Configuration
{
    /// <summary>
    /// 表示启动Nop配置参数
    /// </summary>
    public partial class NopConfig
    {
        /// <summary>
        /// 获取或设置一个值，该值指示是否在生产环境中显示完全错误。
        /// 它在开发环境中被忽略（始终启用)
        /// </summary>
        public bool DisplayFullErrorStack { get; set; }

        /// <summary>
        /// 获取或设置Azure Blob存储的连接字符串
        /// </summary>
        public string AzureBlobStorageConnectionString { get; set; }
        /// <summary>
        /// 获取或设置Azure Blob存储的容器名称
        /// </summary>
        public string AzureBlobStorageContainerName { get; set; }
        /// <summary>
        /// 获取或设置Azure Blob存储的终结点
        /// </summary>
        public string AzureBlobStorageEndPoint { get; set; }
        /// <summary>
        /// 获取或设置是否将或容器名称附加到azureblobstorageendpoint
        /// 构造URL时
        /// </summary>
        public bool AzureBlobStorageAppendContainerName { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应使用Redis服务器
        /// </summary>
        public bool RedisEnabled { get; set; }
        /// <summary>
        /// Gets or sets Redis connection string. Used when Redis is enabled
        /// </summary>
        public string RedisConnectionString { get; set; }
        /// <summary>
        /// 获取或设置特定的Redis数据库；如果需要使用特定的Redis数据库，只需在此处设置其编号。如果应为每个数据类型使用不同的数据库，则设置为空（默认情况下使用）
        /// </summary>
        public int? RedisDatabaseId { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否应将数据保护系统配置为在redis数据库中保留密钥。
        /// </summary>
        public bool UseRedisToStoreDataProtectionKeys { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示是否应使用Redis服务器进行缓存（而不是内存缓存中的默认值）
        /// </summary>
        public bool UseRedisForCaching { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否应使用Redis服务器存储插件信息（而不是默认的plugin.json文件）
        /// </summary>
        public bool UseRedisToStorePluginsInfo { get; set; }

        /// <summary>
        /// 获取或设置具有用户代理字符串的数据库路径
        /// </summary>
        public string UserAgentStringsPath { get; set; }
        /// <summary>
        /// 获取或设置具有仅爬网程序用户代理字符串的数据库的路径
        /// </summary>
        public string CrawlerOnlyUserAgentStringsPath { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示存储所有者是否可以在安装期间安装示例数据
        /// </summary>
        public bool DisableSampleDataDuringInstallation { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否使用快速安装。
        /// 默认情况下，此设置应始终设置为“假”（仅限高级用户）
        /// </summary>
        public bool UseFastInstallationService { get; set; }
        /// <summary>
        /// 获取或设置在NoCommerce安装过程中忽略的插件列表
        /// </summary>
        public string PluginsIgnoredDuringInstallation { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示在应用程序启动时是否清除/plugins/bin目录
        /// </summary>
        public bool ClearPluginShadowDirectoryOnStartup { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示在应用程序启动时是否将“已锁定”程序集从/plugins/bin目录复制到临时子目录
        /// </summary>
        public bool CopyLockedPluginAssembilesToSubdirectoriesOnStartup { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否从上下文将程序集加载到加载中，从而绕过某些安全检查。
        /// </summary>
        public bool UseUnsafeLoadAssembly { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示在应用程序启动时是否将插件库复制到/plugins/bin目录
        /// </summary>
        public bool UsePluginsShadowCopy { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否使用与SQL Server 2008和SQL Server 2008R2的向后兼容性
        /// </summary>
        public bool UseRowNumberForPaging { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在会话状态下存储tempdata。
        /// 默认情况下，基于cookie的tempdata提供程序用于在cookie中存储tempdata。
        /// </summary>
        public bool UseSessionStateTempDataProvider { get; set; }

        /// <summary>
        /// 获取一个值，该值指示是否应使用Azure Blob存储
        /// </summary>
        [JsonIgnore]
        public bool AzureBlobStorageEnabled => !string.IsNullOrEmpty(AzureBlobStorageConnectionString);
    }
}
