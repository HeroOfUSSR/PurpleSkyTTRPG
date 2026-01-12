using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Models
{
    public class Party : BaseAudit
    {
        public string PartyName { get; set; } = string.Empty;

        public string PartyJson { get; set; }

    }
}
