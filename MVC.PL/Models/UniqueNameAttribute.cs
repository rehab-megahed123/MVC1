using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MVcProject.Models;

namespace MVC.DAL.Models
{
    public class UniqueNameAttribute :ValidationAttribute
    {
        

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            if (value == null)
            {
                return null;
            }
            string newName = value.ToString();

            var serviceProvider = validationContext.GetService<IServiceProvider>();
            var _context = serviceProvider.GetRequiredService<ApplicationDBContext>();
            Employee emp = _context.Employees.FirstOrDefault(e => e.Name == newName);

            if (emp != null)
            {
                return new ValidationResult("Name Must be unique");
            }

            else
            {

                return ValidationResult.Success;
            }
        }
    }
}
