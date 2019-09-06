using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Media
{
    /// <summary>
    /// Represents a picture binary data
    /// 表示图像二进制数据
    /// </summary>
    public partial class PictureBinary : BaseEntity
    {
        /// <summary>
        /// Gets or sets the picture binary
        /// 获取或设置图片二进制文件
        /// </summary>
        public byte[] BinaryData { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// 获取或设置图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the picture
        /// 获取或设置图片
        /// </summary>
        public virtual Picture Picture { get; set; }
    }
}
