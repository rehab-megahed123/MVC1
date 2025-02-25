using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Controllers
{
    public class GetSessionContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
