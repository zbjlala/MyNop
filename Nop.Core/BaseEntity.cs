using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core
{
    /// <summary>
    /// Base class for entities
    /// 实体的基类
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }
    }
}
