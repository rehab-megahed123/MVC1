using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [MaxLength(100, ErrorMessage = "The  Length Of Full Name must Be Less Than 100")]
        [MinLength(3, ErrorMessage = "The  Length Of Full Name Must Be more Than 3")]
        [RegularExpression("^[A-Za-z]+$\r\n", ErrorMessage = "The Full Name MUst not Contain Numbers.")]
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
