using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MyNop.Web.FrameWork.Models;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNop.Web.FrameWork.MVC.ModelBinding
{
    /// <summary>
    /// Represents model binder provider for the creating NopModelBinder
    /// 表示用于创建NopModelBinder的模型绑定器提供程序
    /// </summary>
    public class NopModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Creates a nop model binder based on passed context
        /// </summary>
        /// <param name="context">Model binder provider context</param>
        /// <returns>Model binder</returns>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));


            var modelType = context.Metadata.ModelType;
            if (!typeof(BaseNopModel).IsAssignableFrom(modelType))
                return null;

            //use NopModelBinder as a ComplexTypeModelBinder for BaseNopModel
            if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
            {
                //create binders for all model properties
                var propertyBinders = context.Metadata.Properties
                    .ToDictionary(modelProperty => modelProperty, modelProperty => context.CreateBinder(modelProperty));

                return new NopModelBinder(propertyBinders, EngineContext.Current.Resolve<ILoggerFactory>());
            }

            //or return null to further search for a suitable binder
            return null;
        }
    }
}
