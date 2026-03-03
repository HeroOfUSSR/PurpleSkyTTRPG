using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.DataAccess.Postgres.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class LobbyCharacterNoteConfiguration : IEntityTypeConfiguration<LobbyCharacterNoteEntity>
    {
        public void Configure(EntityTypeBuilder<LobbyCharacterNoteEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Text)
                .IsRequired();

            builder.HasOne(x => x.LobbyCharacter)
                .WithMany(x => x.LobbyCharacterNotes)
                .HasForeignKey(x => x.LobbyCharacterId);
        }
    }
}
