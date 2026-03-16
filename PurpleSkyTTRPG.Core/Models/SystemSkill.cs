using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Core.Models
{
    public class SystemSkill
    {
        private SystemSkill(Guid id, GameSystem system, string name, string description)
        {
            Id = id;
            System = system;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public GameSystem System { get; }
        public string Name { get; }
        public string Description { get; }

        public static (SystemSkill SystemSkill, string Error) Create(Guid id, GameSystem system, string name, string description)
        {
            var error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Skill name cannot be empty";
            }
            else if (name.Length > EntityConstraints.MAX_SKILLNAME_LENGTH)
            {
                error = $"Skill name cannot be longer than {EntityConstraints.MAX_SKILLNAME_LENGTH} characters";
            }

            var skill = new SystemSkill(id, system, name, description);

            return (skill, error);
        }
    }
}
