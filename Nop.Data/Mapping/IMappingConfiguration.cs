using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Data.Mapping
{
    /// <summary>
    /// Represents database context model mapping configuration
    /// 表示数据库上下文模型映射配置
    /// </summary>
    public partial interface IMappingConfiguration
    {
        /// <summary>
        /// Apply this mapping configuration
        /// 应用此映射配置
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context</param>
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
