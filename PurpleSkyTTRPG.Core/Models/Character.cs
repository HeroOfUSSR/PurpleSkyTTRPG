using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class Character
    {
        private Character( Guid id, Guid ownerId, GameSystem system, string characterName, string charData)
        {
            Id = id;
            OwnerId = ownerId;
            System = system;
            CharacterName = characterName;
            CharData = charData;
        }

        public Guid Id { get; }
        /// Владелец
        public Guid OwnerId { get; }

        /// К какой системе относится
        public GameSystem System { get; }

        /// Отображаемое имя
        public string CharacterName { get; } = null!;

        /// Лист персонажа
        public string CharData { get; } = null!;

        public static (Character Character, string Error) Create(Guid id, Guid ownerId, GameSystem system, string characterName, string charData)
        {
            var error = string.Empty;

            if (characterName.Length > EntityConstraints.MAX_CHARNAME_LENGTH)
            {
                error = $"Character name cannot be longer than {EntityConstraints.MAX_LOBBYNAME_LENGTH} characters";
            }

            var character = new Character(id, ownerId, system, characterName, charData);

            return (character, error);
        }
    }
}
