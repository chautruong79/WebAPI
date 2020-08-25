using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ex2.Entities;
using Ex2.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex2.Repository
{
    class TaskTempRepository : BaseRepository<TaskTemp>, ITaskTempRepository
    {
        private readonly TaskAssignmentContext _context;
        public TaskTempRepository(TaskAssignmentContext context) : base(context)
        {
            _context = context;
        }
    }
}
