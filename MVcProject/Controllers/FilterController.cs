
using Microsoft.AspNetCore.Authorization;
using MVcProject.Filters;

namespace MVcProject.Controllers
{
    public class FilterController :Controller
    {
        // [HandleError]
        // [Authorize]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            throw new Exception("Exception in Filter Index Action");
        }


    }
}
