using EmployeeKnockOut.Models;

namespace EmployeeKnockOut.Services.IServices
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeModel> GetAll(); 
       Task<EmployeeModel> GetEmployee(int id);
        void DeleteEmployee(int id);    
        int UpdateEmployee (EmployeeModel model);    
        int CreateEmployee (EmployeeModel model);   
    }
}
