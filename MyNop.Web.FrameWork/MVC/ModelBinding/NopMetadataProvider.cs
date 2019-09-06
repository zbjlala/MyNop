using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNop.Web.FrameWork.MVC.ModelBinding
{
    /// <summary>
    /// Represents metadata provider that adds custom attributes to the model's metadata, so it can be retrieved later
    /// 表示向模型元数据添加自定义属性的元数据提供程序，以便稍后检索
    /// </summary>
    public class NopMetadataProvider : IDisplayMetadataProvider
    {
        /// <summary>
        /// Sets the values for properties of isplay metadata
        /// 设置isplay元数据属性的值
        /// </summary>
        /// <param name="context">Display metadata provider context</param>
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            //get all custom attributes
            var additionalValues = context.Attributes.OfType<IModelAttribute>().ToList();

            //and try add them as additional values of metadata
            foreach (var additionalValue in additionalValues)
            {
                if (context.DisplayMetadata.AdditionalValues.ContainsKey(additionalValue.Name))
                    throw new NopException("There is already an attribute with the name '{0}' on this model", additionalValue.Name);

                context.DisplayMetadata.AdditionalValues.Add(additionalValue.Name, additionalValue);
            }
        }
    }
}
