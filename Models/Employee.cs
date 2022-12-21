using System.ComponentModel.DataAnnotations;
namespace EmpManagementSystem.Models
{
    //employee should belong to one of the enum dept
    public enum Dept
    {
        HR=1,
        Finance,
        IT,
        Marketing
    }
    public class Employee
    {
        [Display(Name="Employee Id")]
        [Required(ErrorMessage ="Field cannot be empty")]
        public int Id { get; set; }
        [Display(Name="Employee Name")]
        [Required(ErrorMessage ="Please fill in the name")]
        [MaxLength(75)]
        //Custom validator
        [AllLETTERS(ErrorMessage ="Enter letters only")]

        public string? Name { get; set; }

        [Range(18,80, ErrorMessage ="Please fill in the age between 18 and 80")]
        public int Age { get; set; }
        [Display(Name ="Permanent Address")]
        [DataType(DataType.MultilineText)]
        [MaxLength(250, ErrorMessage ="Address too long")]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public double? Salary { get; set; }
        public string? ImageName { get; set; }


        public Dept Department { get; set; }

    }
}
