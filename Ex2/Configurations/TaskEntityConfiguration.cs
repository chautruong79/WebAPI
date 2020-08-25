using System;
using System.Collections.Generic;
using System.Text;
using Ex2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex2.Configurations
{
    class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(s => s.TaskID);
            builder.HasOne(c => c.Employee)
               .WithMany(g => g.Tasks)
               .HasForeignKey(s => s.EmployeeID);
            builder.HasOne(c => c.Project)
               .WithMany(g => g.Tasks)
               .HasForeignKey(s => s.ProjectID);
            builder.HasData(
                new Task() { TaskID = 1, EmployeeID = 1, ProjectID = 1, WorkingHours = 50 },
                new Task() { TaskID = 2, EmployeeID = 2, ProjectID = 2, WorkingHours = 33 },
                new Task() { TaskID = 3, EmployeeID = 3, ProjectID = 3, WorkingHours = 77 }
                );
        }
    }
}
