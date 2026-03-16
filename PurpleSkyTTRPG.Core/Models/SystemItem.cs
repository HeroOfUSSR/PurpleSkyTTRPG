using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Core.Models
{
    public class SystemItem
    {
        private SystemItem(Guid id, GameSystem system, string name, string desc, double weight, ItemType itemTag, RarityGrade? rarityGrade)
        {
            Id = id;
            System = system;
            Name = name;
            Description = desc;
            Weight = weight;
            ItemTag = itemTag;
            RarityGrade = rarityGrade;
        }

        public Guid Id { get; set; }

        public GameSystem System { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public ItemType ItemTag { get; set; }

        public RarityGrade? RarityGrade { get; set; }

        public static (SystemItem SystemItem, string Error) Create(Guid id, GameSystem system, string name, string desc, double weight, ItemType itemTag, RarityGrade? rarityGrade)
        {
            var error = string.Empty;

            if (name == string.Empty || name == "")
            {
                error = "Item should have name";
            }
            else if (name.Length > EntityConstraints.MAX_ITEMNAME_LENGTH)
                error = $"Item name cannot be longer than {EntityConstraints.MAX_ITEMNAME_LENGTH} characters";

            var systemItem = new SystemItem(id, system, name, desc, weight, itemTag, rarityGrade);

            return (systemItem, error);

        }
    }
}
