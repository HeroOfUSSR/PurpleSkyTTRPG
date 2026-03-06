using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
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
        
        public DbSet<LobbyCharacterEntity> LobbyCharacters { get; set; }

        public DbSet<LobbyCharacterNoteEntity> LobbyCharacterNotes { get; set; }

        public DbSet<LobbyEntity> Lobbies { get; set; }

        public DbSet<LobbyProfileEntity> LobbyProfiles { get; set; }

        public DbSet<ProfileEntity> Profiles { get; set; }

    }
}
