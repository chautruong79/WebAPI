using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ex2
{
    public class TaskAssignmentContext: DbContext
    {
        public TaskAssignmentContext(DbContextOptions<TaskAssignmentContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTemp> EmployeeTemps { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskTemp> TaskTemps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
