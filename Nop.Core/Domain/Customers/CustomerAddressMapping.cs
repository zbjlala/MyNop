using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer-address mapping class
    /// 表示客户地址映射类
    /// </summary>
    public partial class CustomerAddressMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// 获取或设置客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the address identifier
        /// 获取或设置地址标识符
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// 获取或设置地址
        /// </summary>
        public virtual Address Address { get; set; }
    }
}
