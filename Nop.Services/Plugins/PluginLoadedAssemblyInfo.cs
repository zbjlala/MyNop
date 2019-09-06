using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Represents an information about assembly which loaded by plugins
    /// 表示由插件加载的程序集的信息
    /// </summary>
    public partial class PluginLoadedAssemblyInfo
    {
        #region Properties

        /// <summary>
        /// Gets the short assembly name
        /// 获取短程序集名称
        /// </summary>
        public string ShortName { get; }

        /// <summary>
        /// Gets the full assembly name loaded in memory
        /// 获取加载到内存中的完整程序集名称
        /// </summary>
        public string AssemblyFullNameInMemory { get; }

        /// <summary>
        /// Gets a list of all mentioned plugin-assembly pairs
        /// 获取所有提到的插件程序集对的列表
        /// </summary>
        public List<(string PluginName, string AssemblyName)> References { get; }

        /// <summary>
        /// Gets a list of plugins that conflict with the loaded assembly version
        /// 获取与加载的程序集版本冲突的插件列表
        /// </summary>
        public IList<(string PluginName, string AssemblyName)> Collisions =>
            References.Where(reference => !reference.AssemblyName.Equals(AssemblyFullNameInMemory, StringComparison.CurrentCultureIgnoreCase)).ToList();

        #endregion
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="shortName">Assembly short name</param>
        /// <param name="assemblyInMemory">Assembly full name</param>
        public PluginLoadedAssemblyInfo(string shortName, string assemblyInMemory)
        {
            ShortName = shortName;
            References = new List<(string PluginName, string AssemblyName)>();
            AssemblyFullNameInMemory = assemblyInMemory;
        }

        #endregion
    }
}
