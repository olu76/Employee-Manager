using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.MVC.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name =  "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name =  "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        
        
        
        
        
        
        
        

    }
}