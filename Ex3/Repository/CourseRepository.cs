using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex3.Entities;
using Ex3.IRepository;

namespace Ex3.Repository
{
    class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly CourseManagementContext _context;

        public CourseRepository(CourseManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
