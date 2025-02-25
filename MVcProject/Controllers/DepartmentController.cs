




using MVC.BLL.Manager.Abstraction;

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
