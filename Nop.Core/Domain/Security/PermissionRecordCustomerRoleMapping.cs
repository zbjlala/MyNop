using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// Represents a permission record-customer role mapping class
    /// 表示权限记录—客户角色映射类
    /// </summary>
    public partial class PermissionRecordCustomerRoleMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the permission record identifier
        /// 获取或设置权限记录标识符
        /// </summary>
        public int PermissionRecordId { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// 获取或设置客户角色标识符
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// Gets or sets the permission record
        /// 获取或设置权限记录
        /// </summary>
        public virtual PermissionRecord PermissionRecord { get; set; }

        /// <summary>
        /// Gets or sets the customer role
        /// 获取或设置客户角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
