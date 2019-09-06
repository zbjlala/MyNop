using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Infrastructure.Mapper
{
    /// <summary>
    /// Mapper profile registrar interface
    /// Mapper配置文件注册接口
    /// </summary>
    public interface IOrderedMapperProfile
    {
        /// <summary>
        /// Gets order of this configuration implementation
        /// 获取此配置实现的顺序
        /// </summary>
        int Order { get; }
    }
}
