using System.ComponentModel.DataAnnotations;
namespace EmployeeManager.MVC.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "RememberMe")]
        public bool RememberMe{ get; set; }
        
        
        
        
        
        
    }
}