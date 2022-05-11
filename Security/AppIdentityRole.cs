using Microsoft.AspNetCore.Identity;

namespace EmployeeManager.MVC.Security
{
    public class AppIdentityRole: IdentityRole
    {
        public string Description { get; set; }
        
        
    }
}