using EmployeeKnockOut.Data;
using EmployeeKnockOut.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeKnockOut.Services.IServices
{
    public class EmployeeService : IEmployeeService

    {
        private readonly EmployeeKnockOutContext _context;
     
        public EmployeeService(EmployeeKnockOutContext context)
        {

            _context = context; 
 
        }
        public int CreateEmployee(EmployeeModel model)
           
        {
         _context.EmployeeModel.Add(model);
            return _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
        var data =_context.EmployeeModel.FirstOrDefault(x => x.Id == id);
            _context.EmployeeModel.Remove(data);
        
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            var data = _context.EmployeeModel.ToList();
            return data;

        
        }


        public int UpdateEmployee(EmployeeModel model)
        {
           _context.EmployeeModel.Update(model);  
            return _context.SaveChanges();
        }

     public async   Task<EmployeeModel> GetEmployee(int id)
        {
            var data = await _context.EmployeeModel.FirstOrDefaultAsync(e => e.Id == id);
            if (data == null)
            {
               return null;
            }
            return data;
        }
    }
}
