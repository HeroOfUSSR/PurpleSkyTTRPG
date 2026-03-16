using PurpleSkyTTRPG.Core.Constants;
using PurpleSkyTTRPG.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Core.Models
{
    public class SystemSpell
    {
        private SystemSpell(Guid id, GameSystem system, string name, string description)
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

        public static (SystemSpell SystemSpell, string Error) Create(
            Guid id, GameSystem system, string name, string description)
        {
            var error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Spell name cannot be empty";
            }
            else if (name.Length > EntityConstraints.MAX_SPELLNAME_LENGTH)
            {
                error = $"Spell name cannot be longer than {EntityConstraints.MAX_SPELLNAME_LENGTH} characters";
            }

            var spell = new SystemSpell(id, system, name, description);

            return (spell, error);
        }
    }
}
