using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Media
{
    /// <summary>
    /// Represents a picture
    /// 代表了一个图片
    /// </summary>
    public partial class Picture : BaseEntity
    {
        /// <summary>
        /// Gets or sets the picture mime type
        /// 获取或设置图片mime类型
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the SEO friendly filename of the picture
        /// 获取或设置图片的SEO友好文件名
        /// </summary>
        public string SeoFilename { get; set; }

        /// <summary>
        /// Gets or sets the "alt" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// 获取或设置“img”HTML元素的“alt”属性。 如果为空，则使用默认规则(例如产品名称)
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// Gets or sets the "title" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// 获取或设置“img”HTML元素的“title”属性。如果为空，则使用默认规则(例如产品名称)
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the picture is new
        /// 获取或设置一个值，该值指示图片是否是新的
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Gets or sets the picture binary
        /// 获取或设置图片二进制文件
        /// </summary>
        public virtual PictureBinary PictureBinary { get; set; }

        /// <summary>
        /// Gets or sets the picture virtual path
        /// 获取或设置图片虚拟路径
        /// </summary>
        public string VirtualPath { get; set; }
    }
}
