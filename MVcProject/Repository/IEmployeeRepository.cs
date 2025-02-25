using MVcProject.Models;

namespace MVcProject.Repository
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
