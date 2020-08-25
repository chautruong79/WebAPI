using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex2.Entities;
using Ex2.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex2.Repository
{
    class EmployeeTempRepository : BaseRepository<EmployeeTemp>, IEmployeeTempRepository
    {
        private readonly TaskAssignmentContext _context;
        public EmployeeTempRepository(TaskAssignmentContext context) : base(context)
        {
            _context = context;
        }
    }
}
