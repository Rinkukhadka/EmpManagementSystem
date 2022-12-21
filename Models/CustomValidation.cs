using System.ComponentModel.DataAnnotations;
namespace EmpManagementSystem.Models
{

    //custom validator
    public class AllLETTERS:ValidationAttribute
    {
       public override bool IsValid(object? value)
        {
            if(value!=null)
            {
                return ((string)value).All(Char.IsLetter);
            }
            return false;
        }
    }
}
