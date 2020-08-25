using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex3.Entities;
using Ex3.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex3.Repository
{
    class CourseDateRepository : BaseRepository<CourseDate>, ICourseDateRepository
    {
        private readonly CourseManagementContext _context;

        public CourseDateRepository(CourseManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountCourseDate(int courseID)
        {
            return await _context.CourseDates.CountAsync(c => c.CourseID == courseID);
        }
    }
}
