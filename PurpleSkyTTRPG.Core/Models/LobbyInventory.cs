using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Core.Models
{
    public class LobbyInventory
    {
        public Guid Id { get; set; }

        public Guid LobbyId { get; set; }

        public Guid ContributorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }
    }
}
