using PurpleSkyTTRPG.DataAccess.Postgres.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Models
{
    public class CharacterEntity : BaseAudit
    {
        /// Владелец
        public Guid OwnerId { get; set; }

        /// К какой системе относится
        public GameSystem System { get; set; }

        /// Отображаемое имя
        public string CharacterName { get; set; } = null!;

        /// Лист персонажа
        public string DataJson { get; set; } = null!;

        public Guid? PartyId { get; set; }

    }
}
