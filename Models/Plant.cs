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
        public virtual string ImagePath
        {
            get
            {
                string basePath = "pack://application:,,,/Resources/Images/Plants/";
                switch (Stage)
                {
                    case "Seed": return $"{basePath}Seed.png";
                    case "Sprout": return $"{basePath}Sprout.png";
                    case "Mature": return $"{basePath}Mature.png";
                    default: return null;
                }
            }
        }

        public virtual int Price
        {
            get
            {
                switch (Stage)
                {
                    case "Seed": return 5;
                    case "Sprout": return 15;
                    case "Mature": return 25;
                    default: return 0;
                }
            }
        }

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

        // Переменные для настройки роста и здоровья
        protected virtual double GrowthRate => 0.5;
        protected virtual int MaxHealth => 100;
        protected virtual int MaxWaterLevel => 200;
        protected virtual double WaterDecreaseRate => 1.7;
        protected virtual int PestsDamage => 5;
        protected virtual int DroughtDamage => 5;


        public Plant(string name)
        {
            Name = name;
            Height = 1; // Начальная высота
            Health = MaxHealth;
            Stage = "Seed";
            HasPests = false;
            WaterLevel = 30;
        }

        public void Water(int multiplier)
        {
            WaterLevel = Math.Min(WaterLevel + (10*multiplier), MaxWaterLevel);
        }

        public void Fertilize()
        {
            // Удобрение ускоряет рост
            Grow(GrowthRate * 2); 
        }

        public void Grow(double multiply = 1)
        {
            // Растение растет только если его здоровье выше 50%
            if (Health > 50 && WaterLevel < 150)
            {
                Height += GrowthRate * multiply;
                UpdateStage();
            }
        }

        public void Tick(int multiply = 1)
        {
            WaterLevel = Math.Max(WaterLevel - (WaterDecreaseRate * multiply),0);
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
            string oldStage = Stage;
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

            if (oldStage != Stage)
            {
                OnPropertyChanged(nameof(Stage));
                OnPropertyChanged(nameof(ImagePath));
                OnPropertyChanged(nameof(Price));
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
