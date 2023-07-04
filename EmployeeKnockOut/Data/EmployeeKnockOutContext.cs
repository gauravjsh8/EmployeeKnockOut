using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeKnockOut.Models;

namespace EmployeeKnockOut.Data
{
    public class EmployeeKnockOutContext : DbContext
    {
        public EmployeeKnockOutContext (DbContextOptions<EmployeeKnockOutContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeKnockOut.Models.EmployeeModel> EmployeeModel { get; set; } = default!;
    }
}
