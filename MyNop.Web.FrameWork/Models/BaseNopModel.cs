using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MyNop.Web.FrameWork.Models
{
    /// <summary>
    /// Represents base nopCommerce model
    /// 表示基本nopCommerce模型
    /// </summary>
    public partial class BaseNopModel
    {
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public BaseNopModel()
        {
            CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Perform additional actions for binding the model
        /// 执行绑定模型的附加操作
        /// </summary>
        /// <param name="bindingContext">Model binding context</param>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom model binding</remarks>
        public virtual void BindModel(ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Perform additional actions for the model initialization
        /// 为模型初始化执行附加操作
        /// </summary>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom initialization code to constructors</remarks>
        protected virtual void PostInitialize()
        {
        }

        #endregion

        #region Properties

        //There is a bug with a complex model binding in ASP.NET Core, it'll be fixed for further .NET Core  3.0 release (https://github.com/aspnet/AspNetCore/pull/6793). 
        //At now we just add a workaround and remove Form from base model 
        //TODO: uncomment after updating to NET Core 3.0
        ////MVC is suppressing further validation if the IFormCollection is passed to a controller method. That's why we add it to the model
        //[XmlIgnore]
        //public IFormCollection Form { get; set; }

        /// <summary>
        /// Gets or sets property to store any custom values for models 
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, object> CustomProperties { get; set; }

        #endregion

    }
}
