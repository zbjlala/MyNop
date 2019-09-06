using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Media.RoxyFileman
{
    /// <summary>
    /// Represents default values related to roxyFileman
    /// 表示与roxyFileman相关的默认值
    /// </summary>
    public static partial class NopRoxyFilemanDefaults
    {
        /// <summary>
        /// Default path to root directory of uploaded files (if appropriate settings are not specified)
        /// 上传文件的默认根目录路径(如果没有指定适当的设置)
        /// </summary>
        public static string DefaultRootDirectory = "/images/uploaded";

        /// <summary>
        /// Path to configuration file
        /// 配置文件路径
        /// </summary>
        public static string ConfigurationFile = "/lib/Roxy_Fileman/conf.json";

        /// <summary>
        /// Path to directory of language files
        /// 语言文件目录的路径
        /// </summary>
        public static string LanguageDirectory = "/lib/Roxy_Fileman/lang";
    }
}
