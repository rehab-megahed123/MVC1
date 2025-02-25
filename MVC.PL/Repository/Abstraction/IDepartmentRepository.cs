using MVcProject.Models;

namespace MVC.DAL.Repository.Abstraction
{
    public interface IDepartmentRepository
    {
        public void add(Department department);


        public void update(Department department);


        public void delete(int id);


        public List<Department> GetAll();


        public Department GetbyId(int id);


        public void SaveChange();

    }
}
