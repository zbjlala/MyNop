using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// Represents a language
    /// 代表了一种语言
    /// </summary>
    public partial class Language : BaseEntity, IStoreMappingSupported
    {
        /// <summary>
        /// Gets or sets the name
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the language culture
        /// 获取或设置语言文化
        /// </summary>
        public string LanguageCulture { get; set; }

        /// <summary>
        /// Gets or sets the unique SEO code
        /// 获取或设置唯一的SEO代码
        /// </summary>
        public string UniqueSeoCode { get; set; }

        /// <summary>
        /// Gets or sets the flag image file name
        /// 获取或设置标志图像文件名
        /// </summary>
        public string FlagImageFileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the language supports "Right-to-left"
        /// 获取或设置一个值，该值指示语言是否支持“从右到左”
        /// </summary>
        public bool Rtl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// 获取或设置一个值，该值指示实体是否被限制在某些存储中
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the default currency for this language; 0 is set when we use the default currency display order
        /// 获取或设置此语言的默认货币标识符;当使用默认的货币显示顺序时，将设置0
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the language is published
        /// 获取或设置一个值，该值指示是否发布该语言
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
