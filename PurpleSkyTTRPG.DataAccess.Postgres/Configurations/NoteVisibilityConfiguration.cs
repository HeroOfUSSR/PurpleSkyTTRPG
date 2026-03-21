using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Configurations
{
    public class NoteVisibilityConfiguration : IEntityTypeConfiguration<NoteVisibilityEntity>
    {
        public void Configure(EntityTypeBuilder<NoteVisibilityEntity> builder)
        {
            builder.HasKey(x => new { x.LobbyCharacterNoteId, x.ProfileId });

            builder.HasOne(x => x.LobbyCharacterNote)
                .WithMany(x => x.NoteVisibilities)
                .HasForeignKey(x => x.LobbyCharacterNoteId);

            builder.HasOne(x => x.Profile)
                .WithMany()
                .HasForeignKey(x => x.ProfileId);
        }
    }
}
