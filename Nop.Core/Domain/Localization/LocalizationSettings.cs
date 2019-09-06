using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// Localization settings
    /// 本地化设置
    /// </summary>
    public class LocalizationSettings : ISettings
    {
        /// <summary>
        /// Default admin area language identifier
        /// 默认的管理区域语言标识符
        /// </summary>
        public int DefaultAdminLanguageId { get; set; }

        /// <summary>
        /// Use images for language selection
        /// 使用图像进行语言选择
        /// </summary>
        public bool UseImagesForLanguageSelection { get; set; }

        /// <summary>
        /// A value indicating whether SEO friendly URLs with multiple languages are enabled
        /// 一个值，指示是否启用具有多种语言的SEO友好url
        /// </summary>
        public bool SeoFriendlyUrlsForLanguagesEnabled { get; set; }

        /// <summary>
        /// A value indicating whether we should detect the current language by a customer region (browser settings)
        /// 一个值，指示是否应该通过客户区域(浏览器设置)检测当前语言
        /// </summary>
        public bool AutomaticallyDetectLanguage { get; set; }

        /// <summary>
        /// A value indicating whether to load all LocaleStringResource records on application startup
        /// 一个值，指示是否在应用程序启动时加载所有LocaleStringResource记录
        /// </summary>
        public bool LoadAllLocaleRecordsOnStartup { get; set; }

        /// <summary>
        /// A value indicating whether to load all LocalizedProperty records on application startup
        /// 一个值，指示是否在应用程序启动时加载所有LocalizedProperty记录
        /// </summary>
        public bool LoadAllLocalizedPropertiesOnStartup { get; set; }

        /// <summary>
        /// A value indicating whether to load all search engine friendly names (slugs) on application startup
        /// 一个值，指示是否在应用程序启动时加载所有搜索引擎友好名称(slugs)
        /// </summary>
        public bool LoadAllUrlRecordsOnStartup { get; set; }

        /// <summary>
        /// A value indicating whether to we should ignore RTL language property for admin area.
        /// 一个值，指示是否忽略admin区域的RTL语言属性
        /// It's useful for store owners with RTL languages for public store but preferring LTR for admin area
        /// </summary>
        public bool IgnoreRtlPropertyForAdminArea { get; set; }
    }
}
