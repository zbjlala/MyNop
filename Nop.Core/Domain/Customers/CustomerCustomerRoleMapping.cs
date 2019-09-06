using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer-customer role mapping class
    /// 表示客户-客户角色映射类
    /// </summary>
    public partial class CustomerCustomerRoleMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// 获取或设置客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// 获取或设置客户角色标识符
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer role
        /// 获取或设置客户角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
