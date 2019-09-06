using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// Represents a locale string resource
    /// 表示区域设置字符串资源
    /// </summary>
    public partial class LocaleStringResource : BaseEntity
    {
        /// <summary>
        /// Gets or sets the language identifier
        /// 获取或设置语言标识符
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the resource name
        /// 获取或设置资源名称
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the resource value
        /// 获取或设置资源值
        /// </summary>
        public string ResourceValue { get; set; }

        /// <summary>
        /// Gets or sets the language
        /// 获取或设置语言
        /// </summary>
        public virtual Language Language { get; set; }
    }
}
