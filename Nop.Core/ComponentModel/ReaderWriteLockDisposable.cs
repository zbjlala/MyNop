using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Nop.Core.ComponentModel
{
    /// <summary>
    /// Provides a convenience methodology for implementing locked access to resources. 
    /// 提供一种方便的方法来实现对资源的锁定访问
    /// </summary>
    /// <remarks>
    /// Intended as an infrastructure class.
    /// </remarks>
    public class ReaderWriteLockDisposable : IDisposable
    {
        private readonly ReaderWriterLockSlim _rwLock;
        private readonly ReaderWriteLockType _readerWriteLockType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReaderWriteLockDisposable"/> class.
        /// </summary>
        /// <param name="rwLock">The readers–writer lock</param>
        /// <param name="readerWriteLockType">Lock type</param>
        public ReaderWriteLockDisposable(ReaderWriterLockSlim rwLock, ReaderWriteLockType readerWriteLockType = ReaderWriteLockType.Write)
        {
            _rwLock = rwLock;
            _readerWriteLockType = readerWriteLockType;

            switch (_readerWriteLockType)
            {
                case ReaderWriteLockType.Read:
                    _rwLock.EnterReadLock();
                    break;
                case ReaderWriteLockType.Write:
                    _rwLock.EnterWriteLock();
                    break;
                case ReaderWriteLockType.UpgradeableRead:
                    _rwLock.EnterUpgradeableReadLock();
                    break;
            }
        }

        void IDisposable.Dispose()
        {
            switch (_readerWriteLockType)
            {
                case ReaderWriteLockType.Read:
                    _rwLock.ExitReadLock();
                    break;
                case ReaderWriteLockType.Write:
                    _rwLock.ExitWriteLock();
                    break;
                case ReaderWriteLockType.UpgradeableRead:
                    _rwLock.ExitUpgradeableReadLock();
                    break;
            }
        }
    }
}
