using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class StoreItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsPlant { get; set; }
        public Type PlantType { get; set; } 
    }


}
