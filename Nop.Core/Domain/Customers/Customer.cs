using Nop.Core.Domain.Common;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer
    /// 代表一个客户
    /// </summary>
    public partial class Customer : BaseEntity
    {
        private ICollection<ExternalAuthenticationRecord> _externalAuthenticationRecords;
        private ICollection<CustomerCustomerRoleMapping> _customerCustomerRoleMappings;
        private ICollection<ShoppingCartItem> _shoppingCartItems;
        private ICollection<ReturnRequest> _returnRequests;
        protected ICollection<CustomerAddressMapping> _customerAddressMappings;
        private IList<CustomerRole> _customerRoles;

        public Customer()
        {
            CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the customer GUID
        /// 获取或设置客户GUID
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// 获取或设置用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the email that should be re-validated. Used in scenarios when a customer is already registered and wants to change an email address.
        /// 获取或设置应重新验证的电子邮件。用于客户已注册并希望更改电子邮件地址的场景
        /// </summary>
        public string EmailToRevalidate { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// 获取或设置管理注释
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is tax exempt
        /// 获取或设置一个值，该值指示客户是否免税
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// Gets or sets the affiliate identifier
        /// 获取或设置关联标识符
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier with which this customer is associated (maganer)
        /// 获取或设置与此客户关联的供应商标识符(maganer)
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this customer has some products in the shopping cart
        /// 获取或设置一个值，该值指示此客户的购物车中是否有某些产品
        /// <remarks>The same as if we run ShoppingCartItems.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load "ShoppingCartItems" navigation property for each page load
        /// It's used only in a couple of places in the presenation layer
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is required to re-login
        /// 获取或设置一个值，该值指示是否需要重新登录
        /// </summary>
        public bool RequireReLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating number of failed login attempts (wrong password)
        /// 获取或设置一个值，该值指示登录失败次数(密码错误)
        /// </summary>
        public int FailedLoginAttempts { get; set; }

        /// <summary>
        /// Gets or sets the date and time until which a customer cannot login (locked out)
        /// 获取或设置客户无法登录(锁定)之前的日期和时间
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// 获取或设置一个值，该值指示客户是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer has been deleted
        /// 获取或设置一个值，该值指示是否已删除客户
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer account is system
        /// 获取或设置一个值，该值指示客户帐户是否为系统
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// Gets or sets the customer system name
        /// 获取或设置客户系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the last IP address
        /// 获取或设置最后一个IP地址
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// 获取或设置上次登录的日期和时间
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// 获取或设置上次活动的日期和时间
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        /// <summary>
        ///  Gets or sets the store identifier in which customer registered
        ///  获取或设置客户在其中注册的存储标识符
        /// </summary>
        public int RegisteredInStoreId { get; set; }

        /// <summary>
        /// Gets or sets the billing address identifier
        /// 获取或设置计费地址标识符
        /// </summary>
        public int? BillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping address identifier
        /// 获取或设置送货地址标识符
        /// </summary>
        public int? ShippingAddressId { get; set; }

        #region Navigation properties

        /// <summary>
        /// Gets or sets customer generated content
        /// 获取或设置客户生成的内容
        /// </summary>
        public virtual ICollection<ExternalAuthenticationRecord> ExternalAuthenticationRecords
        {
            get => _externalAuthenticationRecords ?? (_externalAuthenticationRecords = new List<ExternalAuthenticationRecord>());
            protected set => _externalAuthenticationRecords = value;
        }

        /// <summary>
        /// Gets or sets customer roles
        /// 获取或设置客户角色
        /// </summary>
        public virtual IList<CustomerRole> CustomerRoles
        {
            get => _customerRoles ?? (_customerRoles = CustomerCustomerRoleMappings.Select(mapping => mapping.CustomerRole).ToList());
        }

        /// <summary>
        /// Gets or sets customer-customer role mappings
        /// 获取或设置客户-客户角色映射
        /// </summary>
        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings
        {
            get => _customerCustomerRoleMappings ?? (_customerCustomerRoleMappings = new List<CustomerCustomerRoleMapping>());
            protected set => _customerCustomerRoleMappings = value;
        }

        /// <summary>
        /// Gets or sets shopping cart items
        /// 获取或设置购物车项
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get => _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>());
            protected set => _shoppingCartItems = value;
        }

        /// <summary>
        /// Gets or sets return request of this customer
        /// 获取或设置此客户的返回请求
        /// </summary>
        public virtual ICollection<ReturnRequest> ReturnRequests
        {
            get => _returnRequests ?? (_returnRequests = new List<ReturnRequest>());
            protected set => _returnRequests = value;
        }

        /// <summary>
        /// Default billing address
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// Default shipping address
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets customer addresses
        /// </summary>
        public IList<Address> Addresses => CustomerAddressMappings.Select(mapping => mapping.Address).ToList();

        /// <summary>
        /// Gets or sets customer-address mappings
        /// </summary>
        public virtual ICollection<CustomerAddressMapping> CustomerAddressMappings
        {
            get => _customerAddressMappings ?? (_customerAddressMappings = new List<CustomerAddressMapping>());
            protected set => _customerAddressMappings = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add customer role and reset customer roles cache
        /// 添加客户角色并重置客户角色缓存
        /// </summary>
        /// <param name="role">Role</param>
        public void AddCustomerRoleMapping(CustomerCustomerRoleMapping role)
        {
            CustomerCustomerRoleMappings.Add(role);
            _customerRoles = null;
        }

        /// <summary>
        /// Remove customer role and reset customer roles cache
        /// 删除客户角色并重置客户角色缓存
        /// </summary>
        /// <param name="role">Role</param>
        public void RemoveCustomerRoleMapping(CustomerCustomerRoleMapping role)
        {
            CustomerCustomerRoleMappings.Remove(role);
            _customerRoles = null;
        }

        #endregion
    }
}
