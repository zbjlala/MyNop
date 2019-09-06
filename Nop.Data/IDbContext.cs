using Microsoft.EntityFrameworkCore;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Data
{
    /// <summary>
    /// Represents DB context
    /// </summary>
    public partial interface IDbContext
    {
        #region Methods

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// 创建可用于查询和保存实体实例的DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Saves all changes made in this context to the database
        /// 将在此上下文中所做的所有更改保存到数据库
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        int SaveChanges();

        /// <summary>
        /// Generate a script to create all tables for the current model
        /// 生成一个脚本，为当前模型创建所有表
        /// </summary>
        /// <returns>A SQL script</returns>
        string GenerateCreateScript();

        /// <summary>
        /// Creates a LINQ query for the query type based on a raw SQL query
        /// 基于原始SQL查询为查询类型创建LINQ查询
        /// </summary>
        /// <typeparam name="TQuery">Query type</typeparam>
        /// <param name="sql">The raw SQL query</param>
        /// <param name="parameters">The values to be assigned to parameters</param>
        /// <returns>An IQueryable representing the raw SQL query</returns>
        IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class;

        /// <summary>
        /// Creates a LINQ query for the entity based on a raw SQL query
        /// 基于原始SQL查询为实体创建LINQ查询
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="sql">The raw SQL query</param>
        /// <param name="parameters">The values to be assigned to parameters</param>
        /// <returns>An IQueryable representing the raw SQL query</returns>
        IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity;

        /// <summary>
        /// Executes the given SQL against the database
        /// 对数据库执行给定的SQL
        /// </summary>
        /// <param name="sql">The SQL to execute</param>
        /// <param name="doNotEnsureTransaction">true - the transaction creation is not ensured; false - the transaction creation is ensured.</param>
        /// <param name="timeout">The timeout to use for command. Note that the command timeout is distinct from the connection timeout, which is commonly set on the database connection string</param>
        /// <param name="parameters">Parameters to use with the SQL</param>
        /// <returns>The number of rows affected</returns>
        int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

        /// <summary>
        /// Detach an entity from the context
        /// 从上下文中分离一个实体
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity</param>
        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;

        #endregion
    }
}
