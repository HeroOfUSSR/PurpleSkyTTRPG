using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class LobbyProfileEntity : BaseAudit
    {
        public Guid LobbyId { get; set; }
        public LobbyEntity Lobby { get; set; }

 
        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }

        public ICollection<NoteVisibilityEntity> NoteVisibilities { get; set; }
    }
}
