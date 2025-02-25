using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Controllers
{
    public class SetSessionController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
        
        public IActionResult Set(string email,string password)
        {
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("password", password);
            return RedirectToAction("Get", "GetSession");

        }

    }
}
