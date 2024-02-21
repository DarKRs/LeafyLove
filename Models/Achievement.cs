using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class Achievement
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsUnlocked { get; private set; }

        public Achievement(string name, string description)
        {
            Name = name;
            Description = description;
            IsUnlocked = false;
        }

        public void Unlock()
        {
            IsUnlocked = true;
        }
    }
}
