using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MVcProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
       
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
            
        }
        [Authorize(Roles ="Admin")]
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        public async Task<IActionResult> SaveRole(AddRoleVM role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = role.RoleName;
                var result=await RoleManager.CreateAsync(identityRole);
                if (result .Succeeded)
                {
                    
                    return View("AddRole");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

               
            }
            
                return View("AddRole", role);
            
        }
    }
}
