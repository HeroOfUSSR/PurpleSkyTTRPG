using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class LobbyConfiguration : IEntityTypeConfiguration<LobbyEntity>
    {
        public void Configure(EntityTypeBuilder<LobbyEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_LOBBYNAME_LENGTH);

            builder.Property(x => x.InviteCode)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_INVITECODE_LENGTH);

            builder.HasIndex(x => x.InviteCode)
                .IsUnique();

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Lobbies)
                .HasForeignKey(x => x.GmId);

        }
    }
}
