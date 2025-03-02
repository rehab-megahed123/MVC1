using Microsoft.AspNetCore.Mvc.Rendering;
using MVcProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace MVcProject.ViewModel
{
    public class emps_LIstOfDepartmentVM
    {
        public int Id { get; set; }
        [Display(Name="Full Name")]
        [Required(ErrorMessage ="This Field Is Required")]
        [MaxLength(100,ErrorMessage ="The  Length Of Full Name must Be Less Than 100")]
        [MinLength(3,ErrorMessage ="The  Length Of Full Name Must Be more Than 3")]
       

        public string Name { get; set; }
        [Required(ErrorMessage ="This Field Is Required")]
        [Range(minimum:20000,maximum:90000,ErrorMessage ="Salary Must Be Between (20_000)and (90_000)")]
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
        
        public string? ImageUrl { get; set; }

        public string? Address { get; set; }

        
       
        public IFormFile formFile { get; set; }


        public int DepartmentId { get; set; }
        public List<Department>? DepartmentList { get; set; }
        public SelectList? DeptOptions { get; set; }
    }
}
