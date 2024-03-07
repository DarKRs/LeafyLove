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

        // Убедитесь, что для всех коллекций установлены публичные сеттеры
        public ObservableCollection<Plant> Plants { get; set; }
        public List<StoreItem> Inventory { get; set; }
        public string FirstPlantName { get; set; }

        // Добавьте конструктор без параметров
        public User()
        {
            // Инициализируйте коллекции здесь, чтобы избежать NullReferenceException при десериализации
            Plants = new ObservableCollection<Plant>();
            Inventory = new List<StoreItem>();
        }

        // Оставьте параметризованный конструктор, если он вам нужен для других целей
        public User(string plantName) : this() // Вызовите конструктор без параметров для инициализации коллекций
        {
            Name = "test";
            Money = 500; // Начальное количество денег
            FirstPlantName = plantName;
            this.AddPlant(new Plant(plantName));
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
