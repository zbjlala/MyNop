using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Infrastructure
{
    public class Singleton<T> : BaseSingletion
    {
        private static T instance;
        /// <summary>
        /// The singleton instance for the specified type T. Only one instance (at the time) of this object for each type of T.
        /// 指定类型T的单例实例。对于每种类型T，该对象(当时)只有一个实例。
        /// </summary>
        public static T Instance
        {
            get => instance;
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
}
