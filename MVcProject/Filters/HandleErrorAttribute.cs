using Microsoft.AspNetCore.Mvc.Filters;

namespace MVcProject.Filters
{
    public class HandleErrorAttribute : Attribute, IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            //catch code
            //ContentResult content = new ContentResult();
            //content.Content = "Some Exception Throw";
            ViewResult view = new ViewResult();
            view.ViewName = "Error";
            context.Result = view; 

        }
    }
}
