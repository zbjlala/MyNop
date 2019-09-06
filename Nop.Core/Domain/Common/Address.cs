using Nop.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// Address
    /// </summary>
    public partial class Address : BaseEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets the first name
        /// 获取或设置名称
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// 获取或设置姓氏
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the company
        /// 获取或设置公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the country identifier
        /// 获取或设置国家标识符
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state/province identifier
        /// 获取或设置状态/省标识符
        /// </summary>
        public int? StateProvinceId { get; set; }

        /// <summary>
        /// Gets or sets the county
        /// 获取或设置县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// 获取或设置城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address 1
        /// 获取或设置地址1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address 2
        /// 获取或设置地址2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the zip/postal code
        /// 获取或设置邮政编码
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// 获取或设置电话号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the fax number
        /// 获取或设置传真号码
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the custom attributes (see "AddressAttribute" entity for more info)
        /// 获取或设置自定义属性(有关更多信息，请参阅“AddressAttribute”实体)
        /// </summary>
        public string CustomAttributes { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// 获取或设置国家
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the state/province
        /// 获取或设置州/省
        /// </summary>
        public virtual StateProvince StateProvince { get; set; }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var addr = new Address
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Company = Company,
                Country = Country,
                CountryId = CountryId,
                StateProvince = StateProvince,
                StateProvinceId = StateProvinceId,
                County = County,
                City = City,
                Address1 = Address1,
                Address2 = Address2,
                ZipPostalCode = ZipPostalCode,
                PhoneNumber = PhoneNumber,
                FaxNumber = FaxNumber,
                CustomAttributes = CustomAttributes,
                CreatedOnUtc = CreatedOnUtc
            };

            return addr;
        }
    }
}
