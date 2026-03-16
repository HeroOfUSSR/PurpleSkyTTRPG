using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class SystemItemEntity : BaseAudit
    {
        public GameSystem System { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public ItemType ItemTag { get; set; }

        public RarityGrade? Rarity { get; set; }
             
    }
}
