using Microsoft.EntityFrameworkCore;
using MVC.DAL.Repository.Abstraction;
using MVcProject.Models;

namespace MVC.DAL.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        
        private readonly ApplicationDBContext db;

        public DepartmentRepository(ApplicationDBContext context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void add(Department department)
        {
            db.Add(department);

        }
        public void update(Department department)
        {
            db.Update(department);
        }
        public void delete(int id)
        {
            Department department = GetbyId(id);
            db.Remove(department);
        }
        public List<Department> GetAll()
        {
            return db.Departments.ToList();

        }
        public Department GetbyId(int id)
        {
            var departmentObj = db.Departments.FirstOrDefault(a => a.Id == id);
            return departmentObj;
        }
        public void SaveChange()
        {
            db.SaveChanges();
        }

    }
}
