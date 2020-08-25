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
    class TaskRepository : BaseRepository<Entities.Task>, ITaskRepository
    {
        private readonly TaskAssignmentContext _context;
        public TaskRepository(TaskAssignmentContext context) : base(context)
        {
            _context = context;
        }
        public override void DeleteRange(IEnumerable<Entities.Task> entities)
        {
            foreach (var task in entities)
            {
                TaskTemp tt = new TaskTemp() { TaskID = task.TaskID, ProjectID = task.ProjectID, EmployeeID = task.EmployeeID, WorkingHours = task.WorkingHours};
                _context.TaskTemps.Add(tt);
            }
            _context.RemoveRange(entities);
        }
    }
}
