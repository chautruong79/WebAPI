using System;
using System.Collections.Generic;
using System.Text;
using Ex3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ex3
{
    public class CourseManagementContext : DbContext
    {
        public CourseManagementContext(DbContextOptions<CourseManagementContext> options)
          : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseDate> CourseDates { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
