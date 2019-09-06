using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Data
{
    /// <summary>
    /// Represents default values related to data settings
    /// 表示与数据设置相关的默认值
    /// </summary>
    public static partial class NopDataSettingsDefaults
    {
        /// <summary>
        /// Gets a path to the file that was used in old nopCommerce versions to contain data settings
        /// 获取旧nopCommerce版本中用于包含数据设置的文件的路径
        /// </summary>
        public static string ObsoleteFilePath => "~/App_Data/Settings.txt";

        /// <summary>
        /// Gets a path to the file that contains data settings
        /// 获取包含数据设置的文件的路径
        /// </summary>
        public static string FilePath => "~/App_Data/dataSettings.json";
    }
}
