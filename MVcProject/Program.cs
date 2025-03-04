using Microsoft.EntityFrameworkCore;
using MVC.BLL.Manager.Abstraction;
using MVC.BLL.Manager.Implementation;
using MVC.DAL.Models;
using MVC.DAL.Repository.Abstraction;
using MVC.DAL.Repository.Implementation;
using MVcProject.Models;


namespace MVcProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddSession(); //default
            //if i want to change default:
            builder.Services.AddSession(options => {
                options.IOTimeout = TimeSpan.FromMinutes(30);
                }
            );
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            var app = builder.Build();
            #region (Custom MiddleWares)
            //app.Use(async(httpContext, Next) =>
            //{
            //    await httpContext.Response.WriteAsync("1)Middle ware1\n");
            //    await Next.Invoke();

            //});
            //app.Use(async(httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("2)Middle WAre2\n");
            //    await next.Invoke();
            //});
            //app.Run(async(httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3)Middle ware3\n");
            //});
            #endregion

            #region (BuiltIn MiddleWare)
            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
            #endregion
            ApplicationDBContext _context = new ApplicationDBContext();
        }
    }
}
