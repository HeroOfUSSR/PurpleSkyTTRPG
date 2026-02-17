using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.DataAccess.Postgres.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres
{
    public class TTRPGDbContext : DbContext
    {
        public TTRPGDbContext (DbContextOptions<TTRPGDbContext> options)
            : base(options)
        {

        }

        public DbSet<CharacterEntity> Characters { get; set; }

        public DbSet<PartyEntity> Parties { get; set; }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }


    }
}
