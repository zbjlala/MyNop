using Nop.Core.Domain.Localization;
using Nop.Core.Domain.SEO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents a vendor
    /// 代表了一个供应商
    /// </summary>
    public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<VendorNote> _vendorNotes;

        /// <summary>
        /// Gets or sets the name
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// 获取或设置图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the address identifier
        /// 获取或设置地址标识符
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// 获取或设置管理注释
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// 获取或设置一个值，该值指示实体是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// 获取或设置一个值，该值指示是否已删除实体
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// 获取或设置元关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// 获取或设置元描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// 获取或设置元标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets the page size
        /// 获取或设置页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers can select the page size
        /// 获取或设置一个值，该值指示客户是否可以选择页面大小
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options
        /// 获取或设置可用的客户可选页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets vendor notes
        /// 获取或设置供应商说明
        /// </summary>
        public virtual ICollection<VendorNote> VendorNotes
        {
            get => _vendorNotes ?? (_vendorNotes = new List<VendorNote>());
            protected set => _vendorNotes = value;
        }
    }
}
