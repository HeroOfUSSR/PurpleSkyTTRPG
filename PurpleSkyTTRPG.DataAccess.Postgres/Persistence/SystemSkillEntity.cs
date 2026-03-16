using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class SystemSkillEntity : BaseAudit
    {
        public GameSystem System { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
