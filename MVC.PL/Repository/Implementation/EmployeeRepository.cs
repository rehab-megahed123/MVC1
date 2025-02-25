using Microsoft.EntityFrameworkCore;
using MVC.DAL.Repository.Abstraction;
using MVcProject.Models;

namespace MVC.DAL.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext db;

        public EmployeeRepository(ApplicationDBContext _context)
        {
            db = _context;
        }
        public void add(Employee employee)
        {
            db.Add(employee);

        }
        public void update(Employee employee)
        {
            db.Update(employee);
        }
        public void delete(int id)
        {
            Employee employee = GetbyId(id);
            db.Remove(employee);
        }
        public List<Employee> GetAll()
        {
            return db.Employees.Include(a => a.Department).ToList();

        }
        public Employee GetbyId(int id)
        {
            var emp = db.Employees.Include(a => a.Department).FirstOrDefault(em => em.Id == id);
            return emp;
        }
        public void SaveChange()
        {
            db.SaveChanges();
        }

    }
}

