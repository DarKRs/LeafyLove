using LeafyLove.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{

    public class Cloves : Plant
    {
        public Cloves(string name) : base(name)
        {
        }

        public override string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/Cloves/Cloves";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }

        protected override double GrowthRate => 0.4;
        protected override double WaterDecreaseRate => 1.5; 
        protected override int PestsDamage => 3; 
        protected override int DroughtDamage => 4;

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 10;
                    case "Sprout": return 20;
                    case "Mature": return 40;
                    default: return 0;
                }
            }
        }
    }

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


        protected override double GrowthRate => 0.3;
        protected override double WaterDecreaseRate => 2.0;
        protected override int PestsDamage => 7;
        protected override int DroughtDamage => 6;

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 20;
                    case "Sprout": return 60;
                    case "Mature": return 100;
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

        protected override double GrowthRate => 0.6;
        protected override double WaterDecreaseRate => 1.8;
        protected override int PestsDamage => 6;
        protected override int DroughtDamage => 5;

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 10;
                    case "Sprout": return 35;
                    case "Mature": return 55;
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

        protected override double GrowthRate => 0.7;
        protected override double WaterDecreaseRate => 1.9;
        protected override int PestsDamage => 5;
        protected override int DroughtDamage => 5;

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 75;
                    case "Sprout": return 140;
                    case "Mature": return 190;
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

        protected override double GrowthRate => 0.2;
        protected override double WaterDecreaseRate => 2.3;
        protected override int PestsDamage => 1;
        protected override int DroughtDamage => 2;

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 100;
                    case "Sprout": return 180;
                    case "Mature": return 250;
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

        protected override double GrowthRate => 0.5;
        protected override double WaterDecreaseRate => 1.4;
        protected override int PestsDamage => 4;
        protected override int DroughtDamage => 4;

        public override int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 50;
                    case "Sprout": return 80;
                    case "Mature": return 130;
                    default: return 0;
                }
            }
        }
    }

}
