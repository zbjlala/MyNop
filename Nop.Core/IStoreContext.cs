using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core
{
    /// <summary>
    /// Store context
    /// 存储环境
    /// </summary>
    public interface IStoreContext
    {
        /// <summary>
        /// Gets the current store
        /// 获取当前存储
        /// </summary>
        Store CurrentStore { get; }

        /// <summary>
        /// Gets active store scope configuration
        /// 获取活动存储范围配置
        /// </summary>
        int ActiveStoreScopeConfiguration { get; }
    }
}
