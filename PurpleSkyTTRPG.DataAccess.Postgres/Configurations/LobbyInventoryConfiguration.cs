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
    public class LobbyInventoryConfiguration : IEntityTypeConfiguration<LobbyInventoryEntity>
    {
        public void Configure(EntityTypeBuilder<LobbyInventoryEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_ITEMNAME_LENGTH);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Weight)
                .IsRequired();

            builder.HasOne(x => x.Lobby)
                .WithMany()
                .HasForeignKey(x => x.LobbyId);

            builder.HasOne(x => x.Profile)
                .WithMany()
                .HasForeignKey(x => x.ContributorId);
        }
    }
}
