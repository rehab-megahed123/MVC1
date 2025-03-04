using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.BLL.Manager.Abstraction;
using MVcProject.Models;
using Microsoft.AspNetCore.Http;


using MVcProject.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace MVcProject.Controllers
{
   
    public class EmployeeController : Controller
    {
        IEmployeeManager employeeManager;
        IDepartmentManager departmentManager;
        public EmployeeController(IEmployeeManager objEmployee,IDepartmentManager objDepartment)
        {
            employeeManager = objEmployee;
            departmentManager = objDepartment;
        }
        public IActionResult Details(int id)
        {
            string msg = "Your current bonus for this month:";
            int bonus1 = 5000;
            int bonus2 = 3000;
            int bonus3 = 2000;
            int bonus4 = 1500;


            var emp = employeeManager.GetbyId(id);
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

            Employee emp = employeeManager.GetbyId(id);
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
            var list = employeeManager.GetAll();
            
            return View("ShowAll", list);

        }
        public IActionResult AddEmployee()
        {
            emps_LIstOfDepartmentVM emps = new emps_LIstOfDepartmentVM();
            emps.DepartmentList = departmentManager.GetAll();
            emps.DeptOptions = new SelectList(emps.DepartmentList, "Id", "Name");



            return View("AddEmployee",emps);
        }
        //Remote Attribute Using Ajax call ==> The Layout must contain scripts of jquery
        public IActionResult CheckName(string Name,string Address)
        {
            if (Name.Contains("ITI"))
            {
                return Json(true);
            }
            return Json(false);
        }

        

        public IActionResult AddEmployeeSave(emps_LIstOfDepartmentVM emp)
        {
            if (ModelState.IsValid == true)
            {
                //Custom Validator
                if (emp.DepartmentId != 0)
                {
                    try
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

                        employeeManager.add(new Employee
                        {
                            Name = emp.Name,
                            Salary = emp.Salary,
                            DepartmentId = emp.DepartmentId,
                            JobTitle = emp.JobTitle,
                            ImageUrl = emp.ImageUrl,
                            Address = emp.Address,
                            formFile = emp.formFile

                        });
                        employeeManager.SaveChange();

                        return RedirectToAction("GetAll");
                    }

                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);

                    }
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "Please select Department");
                }
            }
            

                emp.DepartmentList = departmentManager.GetAll();

                emp.DeptOptions = new SelectList(emp.DepartmentList, "Id", "Name");


                return View("AddEmployee", emp);
            
        }
        
        public IActionResult EditEmployee(int id)
        {
           
            Employee employee1 = new Employee();
            emps_LIstOfDepartmentVM emps = new emps_LIstOfDepartmentVM();
            employee1 = employeeManager.GetbyId(id);
            emps.DepartmentList = departmentManager.GetAll();
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

                var empToUpdate = employeeManager.GetbyId(emp.Id);

                
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


                    employeeManager.update(empToUpdate);
                    employeeManager.SaveChange();
                }

                
                return RedirectToAction("GetAll");
            }

            
            return View("EditEmployee", emp);
        }
        public IActionResult DeleteEmployee(int id)
        {
            
            var emp = employeeManager.GetbyId(id);
            employeeManager.delete(emp.Id);
            employeeManager.SaveChange();
            return RedirectToAction("GetAll");
        }
    }
}
