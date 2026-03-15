using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class LobbyInventoryEntity : BaseAudit
    {
        public Guid LobbyId { get; set; }

        public LobbyEntity Lobby { get; set; }  

        public Guid ContributorId {  get; set; }

        public ProfileEntity Profile { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

    }
}
