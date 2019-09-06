using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// Represents an entity which supports store mapping
    /// 表示支持存储映射的实体
    /// </summary>
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// 获取或设置一个值，该值指示实体是否被限制在某些存储中
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
