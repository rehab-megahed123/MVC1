
using Microsoft.EntityFrameworkCore;
namespace MVcProject.Models
{
    public class ApplicationDBContext :DbContext
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
