using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Caching
{
    public interface ILocker
    {
        /// <summary>
        /// Perform some action with exclusive lock
        /// 使用独占锁执行一些操作
        /// </summary>
        /// <param name="resource">The key we are locking on</param>
        /// <param name="expirationTime">The time after which the lock will automatically be expired</param>
        /// <param name="action">Action to be performed with locking</param>
        /// <returns>True if lock was acquired and action was performed; otherwise false</returns>
        bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action);
    }
}
