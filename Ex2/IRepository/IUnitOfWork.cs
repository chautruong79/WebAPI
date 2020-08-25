using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IEmployeeTempRepository EmployeeTemps { get; }
        ITaskRepository Tasks { get; }
        ITaskTempRepository TaskTemps { get; }
        IProjectRepository Projects { get; }
        Task<int> CommitAsync();
    }
}
