using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        ICourseDateRepository CourseDates { get; }
        Task<int> CommitAsync();
    }
}
