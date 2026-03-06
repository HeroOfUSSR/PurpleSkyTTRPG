using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class LobbyEntity : BaseAudit
    {
        public Guid GmId { get; set; }
        public ProfileEntity Profile { get; set; }

        public string Name { get; set; }

        public GameSystem System { get; set; }

        public string InviteCode { get; set; }


        public ICollection<LobbyProfileEntity> LobbyProfiles { get; set; }
        public ICollection<LobbyCharacterEntity> LobbyCharacters { get; set; }
    }
}
