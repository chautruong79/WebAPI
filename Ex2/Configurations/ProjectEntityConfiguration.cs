using System;
using System.Collections.Generic;
using System.Text;
using Ex2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex2.Configurations
{
    class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(s => s.ProjectID);
            builder.Property(p => p.ProjectName)
                .HasMaxLength(10);
            builder.Property(p => p.Description)
                .HasMaxLength(50);
            builder.Property(p => p.Note)
                .HasMaxLength(100);
            builder.HasData(
                new Project() { ProjectID = 1, ProjectName = "Project1", Note = "1", Description = "1" },
                new Project() { ProjectID = 2, ProjectName = "Project2", Note = "2", Description = "2" },
                new Project() { ProjectID = 3, ProjectName = "Project3", Note = "3", Description = "3" }
                );
        }
    }
}
