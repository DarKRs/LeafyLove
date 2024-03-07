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

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 40;
                    case "Sprout": return 80;
                    case "Mature": return 120;
                    default: return 0;
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

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 40;
                    case "Sprout": return 80;
                    case "Mature": return 120;
                    default: return 0;
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

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 60;
                    case "Sprout": return 120;
                    case "Mature": return 180;
                    default: return 0;
                }
            }
        }
    }

    public class LegoPlant : Plant
    {
        public LegoPlant(string name) : base(name)
        {
        }

        public override string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/Lego/Lego";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 50;
                    case "Sprout": return 100;
                    case "Mature": return 200;
                    default: return 0;
                }
            }
        }
    }

    public class Lilies : Plant
    {
        public Lilies(string name) : base(name)
        {
        }

        public override string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/Lilies/Lilies";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 40;
                    case "Sprout": return 80;
                    case "Mature": return 120;
                    default: return 0;
                }
            }
        }
    }

}
