using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  decimal Salary { get; set; }
        public string JobTitle { get; set; }
        [HiddenInput]
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        [NotMapped]
        [DisplayName("Upload image")]
        public IFormFile formFile { get; set; }

    }
}
