using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// Represents a permission record
    /// 表示权限记录
    /// </summary>
    public partial class PermissionRecord : BaseEntity
    {
        private ICollection<PermissionRecordCustomerRoleMapping> _permissionRecordCustomerRoleMappings;

        /// <summary>
        /// Gets or sets the permission name
        /// 获取或设置权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permission system name
        /// 获取或设置权限系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the permission category
        /// 获取或设置权限类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the permission record-customer role mappings
        /// 获取或设置权限记录—客户角色映射
        /// </summary>
        public virtual ICollection<PermissionRecordCustomerRoleMapping> PermissionRecordCustomerRoleMappings
        {
            get => _permissionRecordCustomerRoleMappings ?? (_permissionRecordCustomerRoleMappings = new List<PermissionRecordCustomerRoleMapping>());
            protected set => _permissionRecordCustomerRoleMappings = value;
        }
    }
}
