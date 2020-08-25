using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex2.Entities;
using Ex2.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex2.Repository
{
    class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly TaskAssignmentContext _context;
        public EmployeeRepository(TaskAssignmentContext context) : base(context)
        {
            _context = context;
        }
        public override void Delete(Employee entity)
        {
            EmployeeTemp et = new EmployeeTemp() { EmployeeID = entity.EmployeeID, FullName = entity.FullName, PhoneNumber = entity.PhoneNumber, Address = entity.Address, Email = entity.Email, DOB = entity.DOB, PayRate = entity.PayRate };
            _context.EmployeeTemps.Add(et);
            _context.Employees.Remove(entity);
        }
    }
}
