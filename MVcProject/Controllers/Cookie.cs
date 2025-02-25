using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Controllers
{
    public class Cookie : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult Set(string email,string password)
        {
            CookieOptions options= new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            //presentation cookie
            HttpContext.Response.Cookies.Append("email",email,options);
            HttpContext.Response.Cookies.Append("password",password,options);
            return RedirectToAction("Get");

        }
        public IActionResult Get()
        {
            string email=HttpContext.Request.Cookies["email"];
            string password=HttpContext.Request.Cookies["password"];
            ViewData["email"] = email;
            ViewData["password"] = password;
            return View("AdminLogin",ViewData);
        }
    }
}
