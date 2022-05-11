using Microsoft.AspNetCore.Identity;

namespace EmployeeManager.MVC.Security
{
    public class AppIdentityUser: IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate  { get; set; }
    }
}