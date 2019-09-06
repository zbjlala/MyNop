using System;
using System.Collections.Generic;
using System.Text;

namespace MyNop.Web.FrameWork.MVC.ModelBinding
{
    /// <summary>
    /// Represents custom model attribute
    /// 表示自定义模型属性
    /// </summary>
    public interface IModelAttribute
    {
        /// <summary>
        /// Gets name of the attribute
        /// </summary>
        string Name { get; }
    }
}
