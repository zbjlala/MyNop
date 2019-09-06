using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Provides access to all "singletons" stored by <see cref="Singleton{T}"/>.
    /// </summary>
    public class BaseSingletion
    {
        /// <summary>
        /// Dictionary of type to singleton instances.
        /// </summary>
        public static IDictionary<Type,object> AllSingletons { get; }
        static BaseSingletion()
        {
            AllSingletons = new Dictionary<Type, object>();
        }
    }
}
