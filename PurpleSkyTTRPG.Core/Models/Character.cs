using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class Character
    {
        private Character(Guid ownerId, GameSystem system, string characterName, string dataJson, Guid partyId)
        {
            OwnerId = ownerId;
            System = system;
            CharacterName = characterName;
            DataJson = dataJson;
            PartyId = partyId;
        }
        /// Владелец
        public Guid OwnerId { get; set; }

        /// К какой системе относится
        public GameSystem System { get; set; }

        /// Отображаемое имя
        public string CharacterName { get; set; } = null!;

        /// Лист персонажа
        public string DataJson { get; set; } = null!;

        public Guid? PartyId { get; set; }

        public static (Character Character, string Error) Create(Guid ownerId, GameSystem system, string characterName, string dataJson, Guid partyId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(dataJson))
            {
                error = "Invalid JSON";
            }

            var character = new Character(ownerId, system, characterName, dataJson, partyId);

            return (character, error);
        }
    }
}
