using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Domain.Models
{
    public class Plant : INotifyPropertyChanged
    {
        private double height;
        private int health;
        private string stage;
        private bool hasPests;
        private double waterLevel;

        public string Name { get; set; }

        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
                UpdateStage();
            }
        }

        public int Health
        {
            get => health;
            set
            {
                health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public double WaterLevel
        {
            get => waterLevel;
            set
            {
                waterLevel = value;
                OnPropertyChanged(nameof(WaterLevel));
            }
        }

        public string Stage
        {
            get => stage;
            private set
            {
                stage = value;
                OnPropertyChanged(nameof(Stage));
            }
        }

        public bool HasPests
        {
            get => hasPests;
            set
            {
                hasPests = value;
                OnPropertyChanged(nameof(HasPests));
            }
        }

        // Константы для настройки роста и здоровья
        private const double GrowthRate = 0.5; // Скорость роста за день без удобрения
        private const int MaxHealth = 100;
        private const int MaxWaterLevel = 200;
        private const double WaterDicreaseRate = 1.7;
        private const int PestsDamage = 10; // Ущерб от вредителей
        private const int DroughtDamage = 5;

        public Plant(string name)
        {
            Name = name;
            Height = 1; // Начальная высота
            Health = MaxHealth;
            Stage = "Seed";
            HasPests = false;
            WaterLevel = 30;
        }

        public void Water()
        {
            WaterLevel = Math.Min(WaterLevel + 15, MaxWaterLevel);
        }

        public void Fertilize()
        {
            // Удобрение ускоряет рост
            Grow(GrowthRate * 2); // Удвоенный рост при удобрении
        }

        public void Grow(double growthAmount = GrowthRate)
        {
            // Растение растет только если его здоровье выше 50%
            if (Health > 50 && WaterLevel < 150)
            {
                Height += growthAmount;
                UpdateStage(); // Обновляем стадию роста в зависимости от высоты
            }
        }

        public void Tick(int multiply = 1)
        {
            WaterLevel -= WaterDicreaseRate * multiply;
            if (WaterLevel < 10)
            {
                Health = Math.Max(Health - DroughtDamage, 0);
            }
            if((WaterLevel > 70 && WaterLevel < 150) && !HasPests)
            {
                Health = Math.Max(Health + 1, MaxHealth);
            }
        }

        public void CheckPests(bool addPests = false)
        {
            if (HasPests)
            {
                // Уменьшаем здоровье из-за вредителей
                Health = Math.Max(Health - PestsDamage, 0);
            }
            if(addPests)
            {
                AddPests();
            }
        }

        private void UpdateStage()
        {
            // Простая логика изменения стадий, можно усложнить в зависимости от требований
            if (Height < 5)
            {
                Stage = "Seed";
            }
            else if (Height < 10)
            {
                Stage = "Sprout";
            }
            else
            {
                Stage = "Mature";
            }
        }

        public void AddPests()
        {
            HasPests = true;
        }

        public void RemovePests()
        {
            HasPests = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
