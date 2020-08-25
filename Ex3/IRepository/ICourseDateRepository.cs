using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex3.Entities;

namespace Ex3.IRepository
{
    public interface ICourseDateRepository : IRepository<CourseDate>
    {
        Task<int> CountCourseDate(int courseID);

    }
}
