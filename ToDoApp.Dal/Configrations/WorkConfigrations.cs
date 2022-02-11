using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Dal.Configrations
{
    public class WorkConfigrations : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.Property(work => work.Defination).HasMaxLength(300);
            builder.Property(work => work.Defination).IsRequired(true);
            builder.Property(work => work.IsCompleted).IsRequired(true);
        }
    }
}
