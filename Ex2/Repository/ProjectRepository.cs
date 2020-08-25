using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex2.Entities;
using Ex2.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex2.Repository
{
    class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly TaskAssignmentContext _context;
        public ProjectRepository(TaskAssignmentContext context) : base(context)
        {
            _context = context;
        }
    }
}
