using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Nop.Core.Data
{
    /// <summary>
    /// Represents data provider type enumeration
    /// 表示数据提供程序类型枚举
    /// </summary>
    public enum DataProviderType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [EnumMember(Value = "")]
        Unknown,

        /// <summary>
        /// MS SQL Server
        /// </summary>
        [EnumMember(Value = "sqlserver")]
        SqlServer
    }
}
