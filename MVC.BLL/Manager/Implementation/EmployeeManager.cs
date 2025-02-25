using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.BLL.Manager.Abstraction;
using MVC.DAL.Repository.Abstraction;
using MVcProject.Models;

namespace MVC.BLL.Manager.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
        }



        public void add(Employee employee)
        {
            _employeeRepository.add(employee);
        }

        public void delete(int id)
        {
            _employeeRepository.delete(id);

        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetbyId(int id)
        {
            return _employeeRepository.GetbyId(id);
        }

        public void SaveChange()
        {
            _employeeRepository.SaveChange();
        }

        public void update(Employee employee)
        {
            _employeeRepository.update(employee);
        }
    }
}
