using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class LobbyConfigurtaion : IEntityTypeConfiguration<LobbyEntity>
    {
        public void Configure(EntityTypeBuilder<LobbyEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Lobby)
                .WithMany(x => x.LobbyProfiles)
                .HasForeignKey(x => x.LobbyId);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.LobbyProfiles)
                .HasForeignKey(x => x.ProfileId);
        }
    }
}
