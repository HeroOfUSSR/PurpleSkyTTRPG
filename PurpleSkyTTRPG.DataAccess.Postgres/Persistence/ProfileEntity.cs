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

        public string ProfileJson { get; set; } = "{}";


        public ICollection<LobbyProfileEntity> LobbyProfiles { get; set; }
        public ICollection<ProfileEntity> Profiles { get; set; }
    }
}
