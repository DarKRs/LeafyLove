using LeafyLove.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class Rose : Plant
    {
        public Rose(string name) : base(name)
        {
        }

        public override string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/Rose/Rose";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }
    }

    public class Tulip : Plant
    {
        public Tulip(string name) : base(name)
        {
        }

        public override string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/Tulip/Tulip";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }
    }

    public class Gypsophila : Plant
    {
        public Gypsophila(string name) : base(name)
        {
        }

        public override string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/Gypsophila/Gypsophila";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }
    }


}
