




using System.Reflection.Metadata;
using MVC.BLL.Manager.Abstraction;
using MVcProject.Models;
using MVcProject.ViewModel;

namespace MVcProject.Controllers
{
    
    public class DepartmentController : Controller
    {

        IDepartmentManager departmentManager;
        public DepartmentController(IDepartmentManager obj)
        {
            departmentManager = obj;
        }

        public IActionResult Index()
        {
           
            List<Department> DepartmentList = departmentManager.GetAll();
            return View("Index",DepartmentList);
        }
       
            
    }
}
