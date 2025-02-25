using Hanan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hanan.Controllers
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowAll()
        {
            var emp = new EmployeeBL();
            var list = emp.ShowAll();
            return View("ShowALL",list);

        }
    }
    
}
