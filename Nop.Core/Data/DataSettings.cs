using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Data
{
    /// <summary>
    /// Represents the data settings
    /// 表示数据设置
    /// </summary>
    public partial class DataSettings
    {
        #region Ctor

        public DataSettings()
        {
            RawDataSettings = new Dictionary<string, string>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a data provider
        /// 获取或设置数据提供程序
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataProviderType DataProvider { get; set; }

        /// <summary>
        /// Gets or sets a connection string
        /// 获取或设置连接字符串
        /// </summary>
        public string DataConnectionString { get; set; }

        /// <summary>
        /// Gets or sets a raw settings
        /// 获取或设置原始设置
        /// </summary>
        public IDictionary<string, string> RawDataSettings { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the information is entered
        /// 获取或设置一个值，该值指示是否输入了信息
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        public bool IsValid => DataProvider != DataProviderType.Unknown && !string.IsNullOrEmpty(DataConnectionString);

        #endregion
    }
}
