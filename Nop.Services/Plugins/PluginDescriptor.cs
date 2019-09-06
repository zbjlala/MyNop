using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Represents a plugin descriptor
    /// 表示插件描述符
    /// </summary>
    public partial class PluginDescriptor : IDescriptor, IComparable<PluginDescriptor>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the plugin group
        /// 获取或设置插件组
        /// </summary>
        [JsonProperty(PropertyName = "Group")]
        public virtual string Group { get; set; }

        /// <summary>
        /// Gets or sets the plugin friendly name
        /// 获取或设置插件友好名称
        /// </summary>
        [JsonProperty(PropertyName = "FriendlyName")]
        public virtual string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the plugin system name
        /// 获取或设置插件系统名称
        /// </summary>
        [JsonProperty(PropertyName = "SystemName")]
        public virtual string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the version
        /// 获取或设置版本
        /// </summary>
        [JsonProperty(PropertyName = "Version")]
        public virtual string Version { get; set; }

        /// <summary>
        /// Gets or sets the supported versions of nopCommerce
        /// 获取或设置nopCommerce支持的版本
        /// </summary>
        [JsonProperty(PropertyName = "SupportedVersions")]
        public virtual IList<string> SupportedVersions { get; set; }

        /// <summary>
        /// Gets or sets the author
        /// 获取或设置作者
        /// </summary>
        [JsonProperty(PropertyName = "Author")]
        public virtual string Author { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// 获取或设置显示顺序
        /// </summary>
        [JsonProperty(PropertyName = "DisplayOrder")]
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the name of the assembly file
        /// 获取或设置程序集文件的名称
        /// </summary>
        [JsonProperty(PropertyName = "FileName")]
        public virtual string AssemblyFileName { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// 获取或设置描述
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of store identifiers in which this plugin is available. If empty, then this plugin is available in all stores
        /// 获取或设置此插件可用的存储标识符列表。如果为空，则此插件可在所有商店中使用
        /// </summary>
        [JsonProperty(PropertyName = "LimitedToStores")]
        public virtual IList<int> LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the list of customer role identifiers for which this plugin is available. If empty, then this plugin is available for all ones.
        /// 获取或设置此插件可用的客户角色标识符列表。如果为空，则此插件适用于所有插件。
        /// </summary>
        [JsonProperty(PropertyName = "LimitedToCustomerRoles")]
        public virtual IList<int> LimitedToCustomerRoles { get; set; }

        /// <summary>
        /// Gets or sets the list of plugins' system name that this plugin depends on
        /// 获取或设置此插件所依赖的插件的系统名称列表
        /// </summary>
        [JsonProperty(PropertyName = "DependsOnSystemNames")]
        public virtual IList<string> DependsOn { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether plugin is installed
        /// 获取或设置指示是否安装插件的值
        /// </summary>
        [JsonIgnore]
        public virtual bool Installed { get; set; }

        /// <summary>
        /// Gets or sets the plugin type
        /// 获取或设置插件类型
        /// </summary>
        [JsonIgnore]
        public virtual Type PluginType { get; set; }

        /// <summary>
        /// Gets or sets the original assembly file that a shadow copy was made from it
        /// 获取或设置由其生成影子副本的原始程序集文件
        /// </summary>
        [JsonIgnore]
        public virtual string OriginalAssemblyFile { get; set; }

        /// <summary>
        /// Gets or sets the assembly that has been shadow copied that is active in the application
        /// 获取或设置已复制的程序集，该程序集在应用程序中处于活动状态
        /// </summary>
        [JsonIgnore]
        public virtual Assembly ReferencedAssembly { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether need to show the plugin on plugins page
        /// 获取或设置一个值，该值指示是否需要在plugins页面上显示插件
        /// </summary>
        [JsonIgnore]
        public virtual bool ShowInPluginsList { get; set; } = true;

        #endregion

        #region Ctor

        public PluginDescriptor()
        {
            SupportedVersions = new List<string>();
            LimitedToStores = new List<int>();
            LimitedToCustomerRoles = new List<int>();
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="referencedAssembly">Referenced assembly</param>
        public PluginDescriptor(Assembly referencedAssembly) : this()
        {
            ReferencedAssembly = referencedAssembly;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the instance of the plugin
        /// 获取插件的实例
        /// </summary>
        /// <typeparam name="TPlugin">Type of the plugin</typeparam>
        /// <returns>Plugin instance</returns>
        public virtual TPlugin Instance<TPlugin>() where TPlugin : class, IPlugin
        {
            //try to resolve plugin as unregistered service
            var instance = EngineContext.Current.ResolveUnregistered(PluginType);

            //try to get typed instance
            var typedInstance = instance as TPlugin;
            if (typedInstance != null)
                typedInstance.PluginDescriptor = this;

            return typedInstance;
        }

        /// <summary>
        /// Compares this instance with a specified PluginDescriptor object
        /// 将此实例与指定的PluginDescriptor对象进行比较
        /// </summary>
        /// <param name="other">The PluginDescriptor to compare with this instance</param>
        /// <returns>An integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified parameter</returns>
        public int CompareTo(PluginDescriptor other)
        {
            if (DisplayOrder != other.DisplayOrder)
                return DisplayOrder.CompareTo(other.DisplayOrder);

            return string.Compare(FriendlyName, other.FriendlyName, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns the plugin as a string
        /// 以字符串的形式返回插件
        /// </summary>
        /// <returns>Value of the FriendlyName</returns>
        public override string ToString()
        {
            return FriendlyName;
        }

        /// <summary>
        /// Determines whether this instance and another specified PluginDescriptor object have the same SystemName
        /// 确定此实例和另一个指定的PluginDescriptor对象是否具有相同的系统名称
        /// </summary>
        /// <param name="value">The PluginDescriptor to compare to this instance</param>
        /// <returns>True if the SystemName of the value parameter is the same as the SystemName of this instance; otherwise, false</returns>
        public override bool Equals(object value)
        {
            return SystemName?.Equals((value as PluginDescriptor)?.SystemName) ?? false;
        }

        /// <summary>
        /// Returns the hash code for this plugin descriptor
        /// 返回此插件描述符的哈希码
        /// </summary>
        /// <returns>A 32-bit signed integer hash code</returns>
        public override int GetHashCode()
        {
            return SystemName.GetHashCode();
        }

        /// <summary>
        /// Save plugin descriptor to the plugin description file
        /// 将插件描述符保存到插件描述文件中
        /// </summary>
        public virtual void Save()
        {
            var fileProvider = EngineContext.Current.Resolve<INopFileProvider>();

            //get the description file path
            if (OriginalAssemblyFile == null)
                throw new Exception($"Cannot load original assembly path for {SystemName} plugin.");

            var filePath = fileProvider.Combine(fileProvider.GetDirectoryName(OriginalAssemblyFile), NopPluginDefaults.DescriptionFileName);
            if (!fileProvider.FileExists(filePath))
                throw new Exception($"Description file for {SystemName} plugin does not exist. {filePath}");

            //save the file
            var text = JsonConvert.SerializeObject(this, Formatting.Indented);
            fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }

        /// <summary>
        /// Get plugin descriptor from the description text
        /// 从描述文本中获取插件描述符
        /// </summary>
        /// <param name="text">Description text</param>
        /// <returns>Plugin descriptor</returns>
        public static PluginDescriptor GetPluginDescriptorFromText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new PluginDescriptor();

            //get plugin descriptor from the JSON file
            var descriptor = JsonConvert.DeserializeObject<PluginDescriptor>(text);

            //nopCommerce 2.00 didn't have 'SupportedVersions' parameter, so let's set it to "2.00"
            if (!descriptor.SupportedVersions.Any())
                descriptor.SupportedVersions.Add("2.00");

            return descriptor;
        }

        #endregion
    }
}
