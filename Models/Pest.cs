using LeafyLove.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class Pest
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }

        public Pest(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

      
    }
}
