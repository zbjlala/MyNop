using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Data.Mapping
{
    /// <summary>
    /// Represents base entity mapping configuration
    /// 表示基本实体映射配置
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class NopEntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        #region Utilities

        /// <summary>
        /// Developers can override this method in custom partial classes in order to add some custom configuration code
        /// 开发人员可以在自定义部分类中重写此方法，以便添加一些自定义配置代码
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the entity
        /// 配置实体
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
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
