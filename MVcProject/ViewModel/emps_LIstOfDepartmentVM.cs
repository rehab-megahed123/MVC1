using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.DAL.Models;

namespace MVcProject.ViewModel
{
    public class emps_LIstOfDepartmentVM
    {
        public int Id { get; set; }
        [Display(Name="Full Name")]
        [Required(ErrorMessage ="This Field Is Required")]
        [MaxLength(100,ErrorMessage ="The  Length Of Full Name must Be Less Than 100")]
        [MinLength(3,ErrorMessage ="The  Length Of Full Name Must Be more Than 3")]
        [UniqueName]
        [Remote(action:"CheckName",controller:"Employee",AdditionalFields ="Address",ErrorMessage ="Student Name Must Contain ITI")]
        public string Name { get; set; }
        [Required(ErrorMessage ="This Field Is Required")]
        [Range(minimum:20000,maximum:90000,ErrorMessage ="Salary Must Be Between (20_000)and (90_000)")]
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
        
        public string? ImageUrl { get; set; }

        public string? Address { get; set; }

        
       
        public IFormFile? formFile { get; set; }


        public int DepartmentId { get; set; }
        public List<Department>? DepartmentList { get; set; }
        public SelectList? DeptOptions { get; set; }
    }
}
