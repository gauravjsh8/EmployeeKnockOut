using System.ComponentModel.DataAnnotations;

namespace EmployeeKnockOut.Models
{
    public class EmployeeModel
    {public int Id { get; set; }    
        public string Name { get; set; }   

        public string Gender { get; set; }  
        
        public string Address { get; set; }   
        public string Department { get; set; }

        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="Please Enter Valid amount of Salary")]

        public string Salary { get; set; }  

    }
}
