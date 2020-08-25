using System;
using System.Collections.Generic;
using System.Text;
using Ex3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Configurations
{
    class CourseDateEntityConfiguration : IEntityTypeConfiguration<CourseDate>
    {
        public void Configure(EntityTypeBuilder<CourseDate> builder)
        {
            builder.ToTable("CourseDate");
            builder.HasKey(s => s.CourseDateID);
            builder.Property(p => p.Details)
                    .HasMaxLength(100);
            builder.Property(p => p.Note)
                    .HasMaxLength(100);
            builder.HasOne(c => c.Course)
                .WithMany(p => p.CourseDates)
                .HasForeignKey(c => c.CourseID);
            //builder.HasData(
            //    new CourseDate() { CourseDateID = 1, Details = "Introduction", Note = "First Day", CourseID = 1 },
            //    new CourseDate() { CourseDateID = 2, Details = "Introduction", Note = "First Day", CourseID = 2 },
            //    new CourseDate() { CourseDateID = 3, Details = "Introduction", Note = "First Day", CourseID = 3 },
            //    new CourseDate() { CourseDateID = 4, Details = "Linear Function", Note = "Second Day", CourseID = 1 }
            //    );
        }
    }
}
