using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// Represents a store
    /// 代表了一个商店
    /// </summary>
    public partial class Store : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the store name
        /// 获取或设置商店名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the store URL
        /// 获取或设置存储URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SSL is enabled
        /// 获取或设置一个值，该值指示是否启用SSL
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// Gets or sets the comma separated list of possible HTTP_HOST values
        /// 获取或设置可能的HTTP_HOST值的逗号分隔列表
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the default language for this store; 0 is set when we use the default language display order
        /// 获取或设置此存储区的默认语言的标识符;当使用默认语言显示顺序时，将设置0
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// 获取或设置公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company address
        /// 获取或设置公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the store phone number
        /// 获取或设置商店电话号码
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the company VAT (used in Europe Union countries)
        /// 获取或设置公司增值税(在欧盟国家使用)
        /// </summary>
        public string CompanyVat { get; set; }
    }
}
