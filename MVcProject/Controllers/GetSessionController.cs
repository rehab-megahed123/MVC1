using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Controllers
{
    public class GetSessionController : Controller
    {
        public IActionResult Get()
        {
            string n = HttpContext.Session.GetString("email");
            string a = HttpContext.Session.GetString("password");
            ViewData["email"] = n;
            ViewData["password"] = a;
            return View("GetLogin",ViewData);
        }
    }
}
