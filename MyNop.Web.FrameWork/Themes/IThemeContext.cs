using System;
using System.Collections.Generic;
using System.Text;

namespace MyNop.Web.FrameWork.Themes
{
    /// <summary>
    /// Represents a theme context
    /// 表示主题上下文
    /// </summary>
    public interface IThemeContext
    {
        /// <summary>
        /// Get or set current theme system name
        /// </summary>
        string WorkingThemeName { get; set; }
    }
}
