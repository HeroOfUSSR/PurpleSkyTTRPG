using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_LOGIN_LENGTH);

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.ProfileJson)
                .IsRequired()
                .HasDefaultValue("{}");

            builder.HasIndex(x => x.Login)
                .IsUnique();
        }
    }
}
