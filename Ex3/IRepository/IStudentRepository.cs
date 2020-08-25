using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex3.Entities;

namespace Ex3.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<int> CountStudents(int courseID);
    }
}
