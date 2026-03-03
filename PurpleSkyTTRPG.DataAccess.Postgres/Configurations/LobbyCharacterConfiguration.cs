using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.DataAccess.Postgres.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class LobbyCharacterConfiguration : IEntityTypeConfiguration<LobbyCharacterEntity>
    {
        public void Configure(EntityTypeBuilder<LobbyCharacterEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Character)
                .WithMany(x => x.LobbyCharacters)
                .HasForeignKey(x => x.CharacterId);

            builder.HasOne(x => x.Lobby)
                .WithMany(x => x.LobbyCharacters)
                .HasForeignKey(x => x.LobbyId);
        }
    }
}
