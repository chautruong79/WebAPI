using System;
using System.Collections.Generic;
using System.Text;
using Ex2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex2.Configurations
{
    class TaskTempEntityConfiguration : IEntityTypeConfiguration<TaskTemp>
    {
        public void Configure(EntityTypeBuilder<TaskTemp> builder)
        {
            builder.ToTable("TaskTemp");
            builder.HasKey(s => s.TaskTempID);
        }
    }
}
