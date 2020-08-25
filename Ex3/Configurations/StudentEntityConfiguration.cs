using System;
using System.Collections.Generic;
using System.Text;
using Ex3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex3.Configurations
{
    class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(s => s.StudentID);
            builder.Property(p => p.FullName)
                .HasMaxLength(20);
            builder.Property(p => p.DOB)
                   .HasColumnName("DateOfBirth")
                   .HasDefaultValueSql("GetDate()");
            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.Property(p => p.Address)
                .HasMaxLength(50);
            builder.Property(p => p.PlaceOfBirth)
                .HasMaxLength(20);
            builder.HasOne(s => s.Course)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.CourseID);
            //builder.HasData(
            //   new Student() { StudentID = 1, FullName = "A A", Address = "Hanoi", DOB = new DateTime(2001, 1, 1), PhoneNumber = "0912345678", PlaceOfBirth = "a@yahoo.com", CourseID = 1 },
            //   new Student() { StudentID = 2, FullName = "B B", Address = "Hanoi", DOB = new DateTime(2002, 1, 1), PhoneNumber = "0912345678", PlaceOfBirth = "b@yahoo.com", CourseID = 2 },
            //    new Student() { StudentID = 3, FullName = "C C", Address = "Hanoi", DOB = new DateTime(2003, 1, 1), PhoneNumber = "0912345678", PlaceOfBirth = "c@yahoo.com", CourseID = 3},
            //    new Student() { StudentID = 4, FullName = "D D", Address = "Hanoi", DOB = new DateTime(2004, 1, 1), PhoneNumber = "0912345678", PlaceOfBirth = "d@yahoo.com", CourseID = 1 }
            //    );
        }
    }
}
