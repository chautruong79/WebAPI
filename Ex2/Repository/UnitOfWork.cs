using System;
using System.Collections.Generic;
using System.Text;
using Ex2.IRepository;

namespace Ex2.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly TaskAssignmentContext _context;

        public UnitOfWork(TaskAssignmentContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            EmployeeTemps = new EmployeeTempRepository(_context);
            Tasks = new TaskRepository(_context);
            TaskTemps = new TaskTempRepository(_context);
            Projects = new ProjectRepository(_context);
        }

        public IEmployeeRepository Employees { get; private set; }
        public IEmployeeTempRepository EmployeeTemps { get; private set; }

        public ITaskRepository Tasks { get; private set; }
        public ITaskTempRepository TaskTemps { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public async System.Threading.Tasks.Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
