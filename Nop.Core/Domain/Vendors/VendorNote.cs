using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents a vendor note
    /// 表示供应商说明
    /// </summary>
    public partial class VendorNote : BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// 获取或设置供应商标识符
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the note
        /// 获取或设置该通知
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the date and time of vendor note creation
        /// 获取或设置创建供应商说明的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets the vendor
        /// 得到了供应商
        /// </summary>
        public virtual Vendor Vendor { get; set; }
    }
}
