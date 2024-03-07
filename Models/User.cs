using LeafyLove.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class User : INotifyPropertyChanged
    {
        private int money;

        public string Name { get; set; }

        public int Money
        {
            get => money;
            set
            {
                if (money != value)
                {
                    money = value;
                    OnPropertyChanged(nameof(Money));
                }
            }
        }

        public ObservableCollection<Plant> Plants { get; private set; }
        public List<StoreItem> Inventory { get; private set; }
        public string FirstPlantName { get; set; }

        public User(string plantName)
        {
            Name = "test";
            Money = 500; // Начальное количество денег
            Plants = new ObservableCollection<Plant>();
            Inventory = new List<StoreItem>();
            FirstPlantName = plantName;
        }

        public void AddPlant(Plant plant)
        {
            Plants.Add(plant);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
