﻿using LeafyLove.Domain.Models;
using LeafyLove.Models;
using LeafyLove.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace LeafyLove.ViewModels
{
    public class PlantViewModel : INotifyPropertyChanged
    {
        private bool canWater = true; // Изначально полив доступен

        private DispatcherTimer tickTimer;
        private DispatcherTimer growthTimer;
        private DispatcherTimer waterTimer;

        Random random = new Random();

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private Plant selectedPlant;
        public Plant SelectedPlant
        {
            get { return selectedPlant; }
            set
            {
                selectedPlant = value;
                OnPropertyChanged(nameof(SelectedPlant));
                // Обновите состояние команд в зависимости от выбранного растения
            }
        }

        /* private Plant plant;

         public Plant Plant
         {
             get { return plant; }
             set
             {
                 plant = value;
                 OnPropertyChanged(nameof(Plant));
             }
         }*/

        // Команды для действий пользователя
        public ICommand WaterCommand { get; private set; }
        public ICommand FertilizeCommand { get; private set; }
        public ICommand TreatCommand { get; private set; }
        public ICommand OpenStoreCommand { get; private set; }

        public PlantViewModel(string plantName)
        {
            User = new User("Имя пользователя"); // Инициализируйте пользователя здесь
            User.AddPlant(new Plant(plantName));
            User.AddPlant(new Plant("Тест2"));
            User.AddPlant(new Plant("Тест3"));
            User.AddPlant(new Plant(plantName));
            User.AddPlant(new Plant(plantName));
            User.AddPlant(new Plant(plantName));
            User.AddPlant(new Plant(plantName));
            User.AddPlant(new Plant(plantName));
            SelectedPlant = User.Plants.First();
            // Plant = new Plant(plantName);

            // Инициализация команд
            WaterCommand = new RelayCommand(_ => WaterPlant(), _ => canWater);
            FertilizeCommand = new RelayCommand(_ => FertilizePlant(), _ => CanFertilizePlant());
            TreatCommand = new RelayCommand(_ => TreatPlant(), _ => CanTreatPlant());

            // Настройка таймера для роста растения
            growthTimer = new DispatcherTimer();
            growthTimer.Interval = TimeSpan.FromSeconds(20);//TimeSpan.FromHours(1); // Установите интервал в соответствии с желаемой скоростью роста
            growthTimer.Tick += GrowthTimer_Tick;
            growthTimer.Start();

            // Настройка таймера для тика растения
            tickTimer = new DispatcherTimer();
            tickTimer.Interval = TimeSpan.FromSeconds(10);//TimeSpan.FromHours(1); // Установите интервал в соответствии с желаемой скоростью роста
            tickTimer.Tick += TickTimer_Tick;
            tickTimer.Start();

            // Настройка таймера задержки полива
            waterTimer = new DispatcherTimer();
            waterTimer.Interval = TimeSpan.FromSeconds(5); // Задержка 30 секунд между поливами
            waterTimer.Tick += WaterTimer_Tick;
        }

        private void GrowthTimer_Tick(object sender, EventArgs e)
        {
            foreach (var plant in User.Plants)
            {
                plant.Grow();
                plant.CheckPests(random.Next(100) < 5);
            }
            OnPropertyChanged(nameof(User.Plants));
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            foreach (var plant in User.Plants)
            {
                plant.Tick(random.Next(10)); 
            }
            OnPropertyChanged(nameof(User.Plants));
        }

        private void WaterTimer_Tick(object sender, EventArgs e)
        {
            canWater = true; // Снова разрешаем полив после задержки
            waterTimer.Stop(); // Останавливаем таймер

            CommandManager.InvalidateRequerySuggested();
        }

        private void WaterPlant()
        {
            SelectedPlant.Water();
            canWater = false; // Блокируем возможность повторного полива
            waterTimer.Start(); // Запускаем таймер задержки
        }*/

        private void WaterPlant()
        {
            if (SelectedPlant != null)
            {
                SelectedPlant.Water();
                canWater = false;
                waterTimer.Start();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private bool CanFertilizePlant()
        {
            return SelectedPlant != null;
        }

        private void FertilizePlant()
        {
            SelectedPlant?.Fertilize();
        }

        private bool CanTreatPlant()
        {
            return SelectedPlant != null && SelectedPlant.HasPests;
        }

        private void TreatPlant()
        {
            SelectedPlant?.RemovePests();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
