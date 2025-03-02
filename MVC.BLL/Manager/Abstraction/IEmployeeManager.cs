using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVcProject.Models;


namespace MVC.BLL.Manager.Abstraction
{
    public interface IEmployeeManager
    {
        
        public void add(Employee employee);
        

        public void update(Employee employee);

        public void delete(int id);

        public List<Employee> GetAll();

        public Employee GetbyId(int id);

        public void SaveChange();
    }
}
