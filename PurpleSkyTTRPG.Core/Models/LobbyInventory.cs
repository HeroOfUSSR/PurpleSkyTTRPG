using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Core.Models
{
    public class LobbyInventory
    {
        private LobbyInventory(Guid id, Guid lobbyId, Guid contributorId, string name, string description, double weight)
        {
            Id = id;
            LobbyId = lobbyId;
            ContributorId = contributorId;
            Name = name;
            Description = description;
            Weight = weight;
        }

        public Guid Id { get; set; }

        public Guid LobbyId { get; set; }

        public Guid ContributorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public static (LobbyInventory LobbyInventory, string Error) Create(Guid id, Guid lobbyId, Guid contributorId, string name, string description, double weight)
        {
            var error = string.Empty;

            if (name == string.Empty || name == "")
            {
                error = "Item should have name";
            }
            else if (lobbyId == Guid.Empty)
            {
                error = "LobbyId cannot be empty";
            }
            else if (contributorId == Guid.Empty)
            {
                error = "ContributorId cannot be empty";
            }

            var lobbyInventory = new LobbyInventory(id, lobbyId, contributorId, name, description, weight);

            return (lobbyInventory, error);
        }
    }
}
