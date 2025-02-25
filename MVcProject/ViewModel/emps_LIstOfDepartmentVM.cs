using MVcProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVcProject.ViewModel
{
    public class emps_LIstOfDepartmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }

        public IFormFile formFile { get; set; }


        public int DepartmentId { get; set; }
        public List<Department> DepartmentList { get; set; }
    }
}
