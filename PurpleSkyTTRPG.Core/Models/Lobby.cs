using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class Lobby
    {
        private Lobby(Guid id, Guid gmId, string name ,GameSystem system, string inviteCode) 
        {
            Id = id;
            GmId = gmId;
            Name = name;
            System = system;
            InviteCode = inviteCode;
        }

        public Guid Id { get;  }

        public Guid GmId { get; }

        public string Name { get; }

        public GameSystem System { get; }

        public string InviteCode { get; }

        public static (Lobby Lobby, string Error) Create(Guid id, Guid gmId, string name, GameSystem system, string inviteCode)
        {
            var error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Lobby name cannot be empty";
            }
            else if (name.Length > EntityConstraints.MAX_LOBBYNAME_LENGTH)
            {
                error = $"Lobby name cannot be longer than {EntityConstraints.MAX_LOBBYNAME_LENGTH} characters";
            }

            var lobby = new Lobby(id, gmId, name, system, inviteCode);

            return (lobby, error);
        }
    }
}
