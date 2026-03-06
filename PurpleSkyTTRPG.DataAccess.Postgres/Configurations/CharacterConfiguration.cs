using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<CharacterEntity>
    {
        public void Configure(EntityTypeBuilder<CharacterEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CharacterName)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_CHARNAME_LENGTH);

            builder.Property(x => x.CharData)
                .IsRequired()
                .HasDefaultValue("{}");
        }
    }
}
