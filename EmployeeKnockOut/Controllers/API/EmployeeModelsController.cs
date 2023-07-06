using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeKnockOut.Data;
using EmployeeKnockOut.Models;
using EmployeeKnockOut.Services.IServices;

namespace EmployeeKnockOut.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly EmployeeKnockOutContext _context;
        private readonly IEmployeeService _Employee;



        public EmployeeModelsController(EmployeeKnockOutContext context, IEmployeeService Employee)
        {
            _context = context;
            _Employee = Employee;
        }

        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<dynamic>> GetEmployeeModel(int skipcount = 0, int take = 0)
        {

            if (_context.EmployeeModel == null)
            {
                return null;
            };
            var result = new
            {
                Data = _Employee.GetAll()
                    .Skip(skipcount)
                    .Take(take).ToList(),
                Total = _context.EmployeeModel.Count()
            };

            
            return result;
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
        {
            if (_context.EmployeeModel == null)
            {
                return NotFound();
            }
            var employeeModel = await _Employee.GetEmployee(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return employeeModel;
        }
        //public List<EmployeeModel> GetEmployeeModel()
        //{
        //    if (_context.EmployeeModel == null)
        //    {
        //        return null;
        //    };


        //    var data = _context.EmployeeModel
        //    .Skip(skipcount)
        //    .Take(take)
        //    .ToList();
        //    if (data == null)
        //    {
        //        return null;
        //    }
        //    return data;
        //}





        // PUT: api/EmployeeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEmployeeModel( int id, EmployeeModel employeeModel)
        {
           if (id !=employeeModel.Id)
            {
                return BadRequest();
            }
           _Employee.UpdateEmployee(employeeModel);
            return Ok();
        }

        // POST: api/EmployeeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(EmployeeModel employeeModel)
        {
            if (_context.EmployeeModel == null)
            {
                return Problem("Entity set 'EmployeeKnockOutContext.EmployeeModel'  is null.");
            }
            _Employee.CreateEmployee(employeeModel);
            return CreatedAtAction("GetEmployeeModel", new { id = employeeModel.Id }, employeeModel);
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public void DeleteEmployeeModel(int id)
        {
            _Employee.DeleteEmployee(id);
        }

        private bool EmployeeModelExists(int id)
        {
            return (_context.EmployeeModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
