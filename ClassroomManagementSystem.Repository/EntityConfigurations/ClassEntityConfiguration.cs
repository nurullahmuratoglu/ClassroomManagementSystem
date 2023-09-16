using ClassroomManagementSystem.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Repository.EntityConfigurations
{
    public class ClassEntityConfiguration : IEntityTypeConfiguration<ClassEntity>
    {
        public void Configure(EntityTypeBuilder<ClassEntity> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);

        }
    }
}
