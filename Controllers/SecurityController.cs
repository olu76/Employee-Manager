using EmployeeManager.MVC.Models;
using EmployeeManager.MVC.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.MVC.Controllers
{
    public class SecurityController: Controller
    {
       private readonly UserManager<AppIdentityUser> userManager;
       private readonly RoleManager<AppIdentityRole> roleManager;
       private readonly SignInManager<AppIdentityUser> signInManager;

       public SecurityController(UserManager<AppIdentityUser> userManager,
        RoleManager<AppIdentityRole> roleManager,
        SignInManager<AppIdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
    }
    [HttpGet]

    public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("Manager").Result)
                {
                   var role = new AppIdentityRole();
                   role.Name = "Manager";
                   role.Description = "can perform crud Operations";
                   var roleResult =roleManager.CreateAsync(role).Result; 
                }

                var user = new AppIdentityUser();
                user.UserName = register.UserName;
                user.Email = register.Email;
                user.FullName = register.FullName;
                user.BirthDate = register.BirthDate;

                var result = userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    
                    return RedirectToAction("SignIn", "Security");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Details"); 
                }
            }

            return View(register);
        }
    }
}
                    
                    
                    
                    
                    
                    
                    
                    
                