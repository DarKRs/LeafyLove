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
        private const int PestsDamage = 10; // Ущерб от вредителей

        public Plant(string name)
        {
            Name = name;
            Height = 1; // Начальная высота
            Health = MaxHealth;
            Stage = "Seed";
            HasPests = false;
        }

        public void Water()
        {
            // Полив увеличивает здоровье растения
            Health = Math.Min(Health + 5, MaxHealth);
        }

        public void Fertilize()
        {
            // Удобрение ускоряет рост
            Grow(GrowthRate * 2); // Удвоенный рост при удобрении
        }

        public void Grow(double growthAmount = GrowthRate)
        {
            // Растение растет только если его здоровье выше 50%
            if (Health > 50)
            {
                Height += growthAmount;
                UpdateStage(); // Обновляем стадию роста в зависимости от высоты
            }
        }

        public void CheckPests()
        {
            if (HasPests)
            {
                // Уменьшаем здоровье из-за вредителей
                Health = Math.Max(Health - PestsDamage, 0);
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
