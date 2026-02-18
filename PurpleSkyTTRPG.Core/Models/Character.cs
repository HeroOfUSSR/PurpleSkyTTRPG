using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class Character
    {
        private Character( Guid id, Guid ownerId, GameSystem system, string characterName, string dataJson, Guid? partyId)
        {
            OwnerId = ownerId;
            System = system;
            CharacterName = characterName;
            DataJson = dataJson;
            PartyId = partyId;
        }

        public Guid Id { get; }
        /// Владелец
        public Guid OwnerId { get; }

        /// К какой системе относится
        public GameSystem System { get; }

        /// Отображаемое имя
        public string CharacterName { get; } = null!;

        /// Лист персонажа
        public string DataJson { get; } = null!;

        public Guid? PartyId { get; }

        public static (Character Character, string Error) Create(Guid id, Guid ownerId, GameSystem system, string characterName, string dataJson, Guid? partyId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(dataJson))
            {
                error = "Invalid JSON";
            }

            var character = new Character(id, ownerId, system, characterName, dataJson, partyId);

            return (character, error);
        }
    }
}
