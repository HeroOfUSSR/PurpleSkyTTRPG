using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string ProfileJson { get; set; } = "{}";



    }
}
