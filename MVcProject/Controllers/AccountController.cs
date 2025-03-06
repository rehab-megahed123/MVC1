using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.DAL.Models.Identity;

namespace MVcProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> Manager;
        private readonly SignInManager<ApplicationUser> SignInManager;
        public AccountController(
            UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> signIn
            )
        {
            Manager = manager;
            SignInManager = signIn;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View("Register");
        }
        public async Task<IActionResult> SaveRegister(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = register.UserName;
                user.Address = register.Address;
                user.PasswordHash = register.Password;

                //save database
                IdentityResult result = await Manager.CreateAsync(user, register.Password);



                //cookie
                if (result.Succeeded) 
                {
                    //assign role 
                   var roleResult=await  Manager.AddToRoleAsync(user, "Admin");
                    if (roleResult.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, false);
                        return RedirectToAction("SignOut");
                    }
                    foreach(var error in roleResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View("Register", register);
        }
        public async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return View("Login");
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                //check found
               ApplicationUser user= await Manager.FindByNameAsync(login.Name);
                if (user != null)
                {
                    if (await Manager.CheckPasswordAsync(user, login.Password) == true)
                    {
                        //create cookie
                        //Add additional info in claims in Cookie
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", user.Address));
                        await SignInManager.SignInWithClaimsAsync(user, login.RememberMe,claims);
                        //await SignInManager.SignInAsync(user, login.RememberMe);
                        return RedirectToAction("GetAll", "Employee");
                    }
                    
                }
                ModelState.AddModelError("", "The password or username are wrong");


                
            }
            return View("Login", login);


        
    }
    }
}
