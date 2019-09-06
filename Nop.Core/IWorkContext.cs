using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core
{
    /// <summary>
    /// Represents work context
    /// 代表的工作环境
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current customer
        /// 获取或设置当前客户
        /// </summary>
        Customer CurrentCustomer { get; set; }

        /// <summary>
        /// Gets the original customer (in case the current one is impersonated)
        /// 获取原始客户(如果模拟了当前客户)
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }

        /// <summary>
        /// Gets the current vendor (logged-in manager)
        /// 获取当前供应商(已登录的管理器)
        /// </summary>
        Vendor CurrentVendor { get; }

        /// <summary>
        /// Gets or sets current user working language
        /// 获取或设置当前用户工作语言
        /// </summary>
        Language WorkingLanguage { get; set; }

        /// <summary>
        /// Gets or sets current user working currency
        /// 获取或设置当前用户工作货币
        /// </summary>
        Currency WorkingCurrency { get; set; }

        /// <summary>
        /// Gets or sets current tax display type
        /// 获取或设置当前税项显示类型
        /// </summary>
        TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether we're in admin area
        /// 获取或设置值，该值指示是否位于管理区域
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
