using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex3.Entities;
using Ex3.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex3.Repository
{
    class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly CourseManagementContext _context;

        public StudentRepository(CourseManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountStudents(int courseID)
        {
            return await _context.Students.CountAsync(c => c.CourseID == courseID);
        }
    }
}
