using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class ProfileEntity : BaseAudit
    {
        public string Login {  get; set; }

        public string PasswordHash { get; set; }

        public string ProfileJson { get; set; } = "{}"; // А нужен ли он вообще?


        public ICollection<LobbyProfileEntity> LobbyProfiles { get; set; }
        public ICollection<LobbyEntity> Lobbies { get; set; }
        public ICollection<LobbyInventoryEntity> LobbyInventories { get; set; }
    }
}
