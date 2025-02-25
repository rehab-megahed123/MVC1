using MVcProject.Models;

namespace MVC.DAL.Repository.Abstraction
{
    public interface IEmployeeRepository
    {
        public void add(Employee employee);

        public void update(Employee employee);

        public void delete(int id);

        public List<Employee> GetAll();

        public Employee GetbyId(int id);

        public void SaveChange();

    }
}
