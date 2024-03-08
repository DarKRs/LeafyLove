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

        public int WaterMultiplier = 1;

        public ObservableCollection<Plant> Plants { get; set; }
        public ObservableCollection<StoreItem> Inventory { get; private set; }
        public string FirstPlantName { get; set; }

        public User()
        {
            Plants = new ObservableCollection<Plant>();
            Inventory = new ObservableCollection<StoreItem>();
        }


        public User(string plantName) : this() 
        {
            Name = "test";
            Money = 50; // Начальное количество денег
            FirstPlantName = plantName;
            this.AddPlant(new Plant(plantName));
        }

        public void AddPlant(Plant plant)
        {
            Plants.Add(plant);
        }

        public void AddToInventory(StoreItem item)
        {
            Inventory.Add(item);
            OnPropertyChanged(nameof(Inventory));
        }

        public bool UseFertilizer()
        {
            var fertilizer = Inventory.FirstOrDefault(i => i.IsFertilizer);
            if (fertilizer != null)
            {
                Inventory.Remove(fertilizer);
                OnPropertyChanged(nameof(Inventory));
                return true;
            }
            return false;
        }

        public bool UsePestControl()
        {
            var pestControl = Inventory.FirstOrDefault(i => i.IsPestControl);
            if (pestControl != null)
            {
                Inventory.Remove(pestControl);
                OnPropertyChanged(nameof(Inventory));
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
