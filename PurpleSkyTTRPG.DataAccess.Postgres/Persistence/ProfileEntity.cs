using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Models
{
    public class ProfileEntity : BaseAudit
    {
        public string Login {  get; set; }

        public string PasswordHash { get; set; }

        public string ProfileJson { get; set; } = "{}"; // А нужен ли он вообще?


        public ICollection<LobbyProfileEntity> LobbyProfiles { get; set; }
        public ICollection<LobbyEntity> Lobbies { get; set; }
    }
}
