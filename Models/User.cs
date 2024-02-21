using LeafyLove.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Plant> Plants { get; private set; }
        public List<StoreItem> Inventory { get; private set; }

        public User(string name)
        {
            Name = name;
            Money = 0; // Начальное количество денег
            Plants = new List<Plant>();
            Inventory = new List<StoreItem>();
        }

        public void AddPlant(Plant plant)
        {
            Plants.Add(plant);
        }
    }
}
