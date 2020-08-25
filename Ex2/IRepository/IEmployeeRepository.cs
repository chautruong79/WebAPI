using System;
using System.Collections.Generic;
using System.Text;
using Ex2.Entities;

namespace Ex2.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
