using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a currency
    /// </summary>
    public partial class Currency : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        /// <summary>
        /// Gets or sets the name
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the currency code
        /// 获取或设置货币代码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the rate
        /// 获取或设置速率
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the display locale
        /// 获取或设置显示区域设置
        /// </summary>
        public string DisplayLocale { get; set; }

        /// <summary>
        /// Gets or sets the custom formatting
        /// 获取或设置自定义格式
        /// </summary>
        public string CustomFormatting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// 获取或设置一个值，该值指示实体是否被限制在某些存储中
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// 获取或设置一个值，该值指示是否发布实体
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the rounding type identifier
        /// 获取或设置舍入类型标识符
        /// </summary>
        public int RoundingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the rounding type
        /// 获取或设置舍入类型
        /// </summary>
        public RoundingType RoundingType
        {
            get => (RoundingType)RoundingTypeId;
            set => RoundingTypeId = (int)value;
        }
    }
}
