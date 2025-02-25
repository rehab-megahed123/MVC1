using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.BLL.Manager.Abstraction;
using MVC.DAL.Repository.Abstraction;
using MVC.DAL.Repository.Implementation;

using MVcProject.Models;

namespace MVC.BLL.Manager.Implementation
{

    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository departmentRepository;

        
        public DepartmentManager(IDepartmentRepository departmentRepo)
        {
            departmentRepository = departmentRepo ?? throw new ArgumentNullException(nameof(departmentRepo));
        }

        public void add(Department department)
        {
            departmentRepository.add(department);
        }

        public void delete(int id)
        {
            departmentRepository.delete(id);
        }

        public List<Department> GetAll()
        {
           return departmentRepository.GetAll();
        }

        public Department GetbyId(int id)
        {
            return departmentRepository.GetbyId(id);
        }

        public void SaveChange()
        {
            departmentRepository.SaveChange();
        }

        public void update(Department department)
        {
            departmentRepository.update(department);
        }
    }
}
