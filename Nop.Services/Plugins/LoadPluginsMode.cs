using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Plugins
{
    /// <summary>
    /// Represents a mode to load plugins
    /// 表示加载插件的模式
    /// </summary>
    public enum LoadPluginsMode
    {
        /// <summary>
        /// All (Installed and Not installed)
        /// </summary>
        All = 0,

        /// <summary>
        /// Installed only
        /// </summary>
        InstalledOnly = 10,

        /// <summary>
        /// Not installed only
        /// </summary>
        NotInstalledOnly = 20
    }
}
