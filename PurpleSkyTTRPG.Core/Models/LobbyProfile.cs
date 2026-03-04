using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class LobbyProfile
    {
        private LobbyProfile(Guid id, Guid lobbyId, Guid profileId)
        {
            Id = id;
            LobbyId = lobbyId;
            ProfileId = profileId;
        }

        public Guid Id { get; }
        public Guid LobbyId { get; }
        public Guid ProfileId { get; }

        public static (LobbyProfile LobbyProfile, string Error) Create(Guid id, Guid lobbyId, Guid profileId)
        {
            var error = string.Empty;

            if (lobbyId == Guid.Empty)
            {
                error = "LobbyId cannot be empty";
            }
            else if (profileId == Guid.Empty)
            {
                error = "ProfileId cannot be empty";
            }
                
            var lobbyProfile = new LobbyProfile(id, lobbyId, profileId);

            return (lobbyProfile, error);
        }
    }
}
