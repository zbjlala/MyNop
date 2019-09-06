using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Data.Mapping
{
    /// <summary>
    /// Represents base query type mapping configuration
    /// 表示基本查询类型映射配置
    /// </summary>
    /// <typeparam name="TQuery">Query type type</typeparam>
    public partial class NopQueryTypeConfiguration<TQuery> : IMappingConfiguration, IQueryTypeConfiguration<TQuery> where TQuery : class
    {
        #region Utilities

        /// <summary>
        /// Developers can override this method in custom partial classes in order to add some custom configuration code
        /// 开发人员可以在自定义部分类中重写此方法，以便添加一些自定义配置代码
        /// </summary>
        /// <param name="builder">The builder to be used to configure the query</param>
        protected virtual void PostConfigure(QueryTypeBuilder<TQuery> builder)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the query type
        /// 配置查询类型
        /// </summary>
        /// <param name="builder">The builder to be used to configure the query type</param>
        public virtual void Configure(QueryTypeBuilder<TQuery> builder)
        {
            //add custom configuration
            PostConfigure(builder);
        }

        /// <summary>
        /// Apply this mapping configuration
        /// 应用此映射配置
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context</param>
        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        #endregion
    }
}
