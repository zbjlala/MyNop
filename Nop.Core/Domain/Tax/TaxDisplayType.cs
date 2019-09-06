using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Tax
{
    /// <summary>
    /// Represents the tax display type enumeration
    /// 表示税务显示类型枚举
    /// </summary>
    public enum TaxDisplayType
    {
        /// <summary>
        /// Including tax
        /// 含税
        /// </summary>
        IncludingTax = 0,

        /// <summary>
        /// Excluding tax
        /// 不含税
        /// </summary>
        ExcludingTax = 10
    }
}
