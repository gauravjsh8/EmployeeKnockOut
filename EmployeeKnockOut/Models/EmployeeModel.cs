using System.ComponentModel.DataAnnotations;

namespace EmployeeKnockOut.Models
{
    public class EmployeeModel
    {public int Id { get; set; }
        [Required]
        public string Name { get; set; }   

        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Department { get; set; }

        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="Please Enter Valid amount of Salary")]
        [Required]
        public string Salary { get; set; }  

    }
}
