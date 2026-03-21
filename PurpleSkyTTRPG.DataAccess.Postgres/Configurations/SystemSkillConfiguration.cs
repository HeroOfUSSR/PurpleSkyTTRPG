using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class SystemSkillConfiguration : IEntityTypeConfiguration<SystemSkillEntity>
    {
        public void Configure(EntityTypeBuilder<SystemSkillEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_SKILLNAME_LENGTH);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.HasIndex(x => x.System);
        }
    }
}
