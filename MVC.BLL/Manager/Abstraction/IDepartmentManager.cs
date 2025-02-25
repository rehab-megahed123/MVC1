using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.Repository.Implementation;
using MVcProject.Models;

namespace MVC.BLL.Manager.Abstraction
{
    public interface IDepartmentManager
    {
        

        public void add(Department department);


        public void update(Department department);


        public void delete(int id);


        public List<Department> GetAll();


        public Department GetbyId(int id);


        public void SaveChange();
    }
}
