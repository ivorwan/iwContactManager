using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iwContactManager.Models.Validators
{
    public class ValidatorModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {

            if (modelType.Equals(typeof(AValidator)))
            {
                Type instantiationType = null;

                //string type = bindingContext.ValueProvider.GetValue("ValidatorType").ToString();
                string type = controllerContext.HttpContext.Request.Form["ValidatorType"];
                instantiationType = Type.GetType(string.Format("iwContactManager.Models.Validators.{0}", type));

                var obj = Activator.CreateInstance(instantiationType);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, instantiationType);
                bindingContext.ModelMetadata.Model = obj;

                return obj;

            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

        //public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    string type = controllerContext.HttpContext.Request.Form["ValidatorType"];
        //    bindingContext.ModelName = type;


        //    bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, Type.GetType(string.Format("iwContactManager.Models.Validators.{0}", type)));
        //    return base.BindModel(controllerContext, bindingContext);
        //}
    }
}