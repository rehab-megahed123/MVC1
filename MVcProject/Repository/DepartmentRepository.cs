using Microsoft.EntityFrameworkCore;
using MVcProject.Models;

namespace MVcProject.Repository
{
    public class DepartmentRepository :IDepartmentRepository
    {
        ApplicationDBContext db;
        public DepartmentRepository(ApplicationDBContext _conext)
        {
            db = _conext;
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
           Department department=GetbyId(id);
           db.Remove(department);
        }
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
            
        }
        public Department GetbyId(int id)
        {
            var departmentObj=db.Departments.FirstOrDefault(a => a.Id == id);
            return departmentObj;
        }
        public void SaveChange()
        {
            db.SaveChanges();
        }

    }
}
