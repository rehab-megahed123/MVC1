using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVcProject.Models;
using MVcProject.Repository;
using MVcProject.ViewModel;

namespace MVcProject.Controllers
{
   
    public class EmployeeController : Controller
    {
        IEmployeeRepository employeeRepository;
        IDepartmentRepository departmentRepository;
        public EmployeeController(IEmployeeRepository objEmployee,IDepartmentRepository objDepartment)
        {
            employeeRepository = objEmployee;
            departmentRepository = objDepartment;
        }
        public IActionResult Details(int id)
        {
            string msg = "Your current bonus for this month:";
            int bonus1 = 5000;
            int bonus2 = 3000;
            int bonus3 = 2000;
            int bonus4 = 1500;


            var emp = employeeRepository.GetbyId(id);
            ViewData["msg"] = msg;
            ViewData["bonus1"] = bonus1;
            ViewData["bonus2"] = bonus2;
            ViewData["bonus3"] = bonus3;
            ViewBag.bonus4 = bonus4;
            ViewBag.color = "red";
           
            ViewData["emp"] = emp;
            return View("Details",emp);

            
            
        }
        public IActionResult DetailsVM(int id)
        {

            Employee emp = employeeRepository.GetbyId(id);
            Empbonus_emps_detailsViewModel vm1=new Empbonus_emps_detailsViewModel();
            vm1.EmpName = emp.Name;
            vm1.Salary = emp.Salary;
            vm1.image = emp.ImageUrl;
            vm1.DeptName = emp.Department.Name;
            vm1.bonus=vm1.defineBonus(emp.DepartmentId);
            vm1.SalaryAfterBonus = vm1.CalculateSalaryAfterBonus(emp.Salary,vm1.bonus);
            vm1.Color = "red";
            return View("DetailsVM",vm1);
        }
        public IActionResult GetAll()
        {
            var list = employeeRepository.GetAll();
            
            return View("ShowAll", list);

        }
        public IActionResult AddEmployee()
        {
            emps_LIstOfDepartmentVM emps = new emps_LIstOfDepartmentVM();
            emps.DepartmentList = departmentRepository.GetAll();
           


            return View("AddEmployee",emps);
        }

        

        public IActionResult AddEmployeeSave(Employee emp)
        {
            if ( emp.Name != null && emp.DepartmentId != null && emp.Salary != null && emp.JobTitle != null)
            {

                if (emp.formFile != null && emp.formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", emp.formFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        emp.formFile.CopyTo(stream);
                    }

                    emp.ImageUrl = "/images/" + emp.formFile.FileName;
                }




                
                employeeRepository.add(emp);
                employeeRepository.SaveChange();

                return RedirectToAction("GetAll");
            }
            emps_LIstOfDepartmentVM emps = new emps_LIstOfDepartmentVM();
            emps.DepartmentList = departmentRepository.GetAll();
            emps.Name = emp.Name;
            emps.Salary = emp.Salary;
            emps.DepartmentId = emp.DepartmentId;
            emps.Address = emp.Address;
            emps.JobTitle = emp.JobTitle;
            emps.ImageUrl = emp.ImageUrl;

            return View ("AddEmployee",emps);

        }
        public IActionResult EditEmployee(int id)
        {
           
            Employee employee1 = new Employee();
            emps_LIstOfDepartmentVM emps = new emps_LIstOfDepartmentVM();
            employee1 = employeeRepository.GetbyId(id);
            emps.DepartmentList = departmentRepository.GetAll();
            emps.Name = employee1.Name;
            emps.Address = employee1.Address;
            emps.DepartmentId = employee1.DepartmentId;
            emps.ImageUrl = employee1.ImageUrl;
            emps.JobTitle=employee1.JobTitle;
            emps.Salary = employee1.Salary;
            emps.Id = employee1.Id;

            return View("EditEmployee",emps);
        }
        [HttpPost]
        
        public IActionResult EditEmployeeSave(Employee emp)
        {
            if (emp.Id != null && emp.Name != null && emp.Salary != null && emp.JobTitle != null && emp.DepartmentId != null)
            {

                var empToUpdate = employeeRepository.GetbyId(emp.Id);

                
                if (empToUpdate != null)
                {
                    empToUpdate.Name = emp.Name;
                    empToUpdate.Salary = emp.Salary;
                    empToUpdate.Address = emp.Address;
                    empToUpdate.JobTitle = emp.JobTitle;
                    empToUpdate.DepartmentId = emp.DepartmentId;

                    
                    if (emp.formFile != null && emp.formFile.Length > 0)
                    {
                        
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(emp.formFile.FileName);

                        
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                        
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            emp.formFile.CopyTo(stream);
                        }

                        
                        empToUpdate.ImageUrl = "/images/" + fileName;
                    }
                    else
                    {
                        
                        empToUpdate.ImageUrl = empToUpdate.ImageUrl;
                    }


                    employeeRepository.update(empToUpdate);
                    employeeRepository.SaveChange();
                }

                
                return RedirectToAction("GetAll");
            }

            
            return View("EditEmployee", emp);
        }
        public IActionResult DeleteEmployee(int id)
        {
            
            var emp = employeeRepository.GetbyId(id);
            employeeRepository.delete(emp.Id);
            employeeRepository.SaveChange();
            return RedirectToAction("GetAll");
        }
    }
}
