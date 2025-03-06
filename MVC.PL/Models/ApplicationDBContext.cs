
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.DAL.Models.Identity;
namespace MVcProject.Models
{
    public class ApplicationDBContext :IdentityDbContext<ApplicationUser>
    {

       public DbSet<Employee> Employees { get; set; }   
       public DbSet<Department> Departments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=MVCL;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public ApplicationDBContext() : base()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

    }
}
