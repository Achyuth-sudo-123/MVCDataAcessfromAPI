using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using System.Web.Mvc;

namespace MVCDataAcessfromAPI.Helpers
{
    public class ExceptionFilters : IExceptionFilter
    {
        public  void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),context.ModelState)
                {

                    {"UID",context.Exception.Message }

                }
            };
        }
    }
}
