using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex3.IRepository;

namespace Ex3.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly CourseManagementContext _context;
        private StudentRepository _students;
        private CourseRepository _courses;
        private CourseDateRepository _courseDates;

        public UnitOfWork(CourseManagementContext context)
        {
            _context = context;
        }
        public IStudentRepository Students => _students ??= new StudentRepository(_context);

        public ICourseRepository Courses => _courses ??= new CourseRepository(_context);

        public ICourseDateRepository CourseDates => _courseDates ??= new CourseDateRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
