using System;
using System.Collections.Generic;
using System.Text;
using Ex3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Configurations
{
    class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(s => s.CourseID);
            builder.Property(p => p.CourseName)
                    .HasMaxLength(10);
            builder.Property(p => p.Description)
                .HasMaxLength(100);
            builder.Property(p => p.StartDate)
                .HasDefaultValueSql("GetDate()");
            builder.Property(p => p.EndDate)
               .HasDefaultValueSql("GetDate()");
            //builder.HasData(
            //    new Course() { CourseID = 1, CourseName = "Math", Description = "Training", StartDate = new DateTime(2020, 8, 30), EndDate = new DateTime(2020, 9, 10), Tuition = 5500000 },
            //    new Course() { CourseID = 2, CourseName = "Biology", Description = "Training", StartDate = new DateTime(2020, 7, 25), EndDate = new DateTime(2020, 8, 05), Tuition = 4000000 },
            //    new Course() { CourseID = 3, CourseName = "IT", Description = "Training", StartDate = new DateTime(2020, 9, 11), EndDate = new DateTime(2020, 9, 20), Tuition = 3700000 }
            //    );
        }
    }
}
