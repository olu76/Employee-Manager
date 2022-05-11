using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Models
{
  [Table("Employees")]
  public class Employee
  {
    [Column("EmployeeID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required(ErrorMessage = "Employee ID is Required")]
    [Display(Name =  "First Name")]
     public int EmployeeID { get; set; }
     [Column("FirstName")]
     [Display(Name =  "First Name")]
     [StringLength(20, ErrorMessage = ("First name must be less than 20 characters"))]
    [Required(ErrorMessage = "Employee First Name is Required")]
    public string  FirstName { get; set; }
    [Column("LastName")]
     [Display(Name =  "Last Name")]
     [StringLength(20, ErrorMessage = ("Last name must be less than 30 characters"))]
    [Required(ErrorMessage = "Employee Last Name is Required")]
    public string  LastName { get; set; }
    [Column("Title")]
     [Display(Name =  "Title")]
     [StringLength(20, ErrorMessage = ("Title must be less than 30 characters"))]
    [Required(ErrorMessage = "Employee Title is Required")] 
    public string  Title { get; set; }
    [Column("BirthDate")]
     [Display(Name =  "BirthDate")]
    [Required(ErrorMessage = "Employee Birth Date is Required")]
    public DateTime BirthDate { get; set; }
    [Column("HireDate")]
     [Display(Name =  "HireDate")]
    [Required(ErrorMessage = "Employee Hire Date is Required")]
    public DateTime HireDate { get; set; }
   [ Column("Country")]
     [Display(Name =  "Country")]
     [StringLength(20, ErrorMessage = ("Country must be less than 30 characters"))]
    [Required(ErrorMessage = "Employee Country is Required")]
    public string Country { get; set; }
     [ Column("Notes")]
     [Display(Name =  "Notes")]
     [StringLength(20, ErrorMessage = ("Notes must be less than 500 characters"))]
    public string Notes { get; set; }
    
    
    
    
  }
}
  
