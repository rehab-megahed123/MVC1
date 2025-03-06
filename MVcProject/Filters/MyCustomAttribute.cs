using Microsoft.AspNetCore.Mvc.Filters;

namespace MVcProject.Filters
{
    public class MyCustomAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //before action execution
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //after action execution
            
        }
    }
}
