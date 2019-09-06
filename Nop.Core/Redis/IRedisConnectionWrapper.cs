using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Nop.Core.Redis
{
    /// <summary>
    /// Represents Redis connection wrapper
    /// 表示Redis连接包装器
    /// </summary>
    public interface IRedisConnectionWrapper : IDisposable
    {
        /// <summary>
        /// Obtain an interactive connection to a database inside Redis
        /// 获取到Redis内部数据库的交互连接
        /// </summary>
        /// <param name="db">Database number</param>
        /// <returns>Redis cache database</returns>
        IDatabase GetDatabase(int db);

        /// <summary>
        /// Obtain a configuration API for an individual server
        /// 获取单个服务器的配置API
        /// </summary>
        /// <param name="endPoint">The network endpoint</param>
        /// <returns>Redis server</returns>
        IServer GetServer(EndPoint endPoint);

        /// <summary>
        /// Gets all endpoints defined on the server
        /// 获取服务器上定义的所有端点
        /// </summary>
        /// <returns>Array of endpoints</returns>
        EndPoint[] GetEndPoints();

        /// <summary>
        /// Delete all the keys of the database
        /// </summary>
        /// <param name="db">Database number</param>
        void FlushDatabase(RedisDatabaseNumber db);
    }
}
