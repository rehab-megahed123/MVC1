




namespace MVcProject.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository obj)
        {
            departmentRepository = obj;
        }

        public IActionResult Index()
        {
            List<Department> DepartmentList = departmentRepository.GetAll();
            
            return View("Index",DepartmentList);
        }
    }
}
