﻿using LeafyLove.Domain.Models;
using LeafyLove.Models;
using LeafyLove.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace LeafyLove.ViewModels
{
    public class PlantViewModel : INotifyPropertyChanged
    {
        private bool canWater = true; // Изначально полив доступен

        private TimeOfDayToBackgroundConverter converter = new TimeOfDayToBackgroundConverter();

        private DispatcherTimer tickTimer;
        private DispatcherTimer growthTimer;
        private DispatcherTimer waterTimer;
        private DispatcherTimer backgroundUpdateTimer;

        Random random = new Random();

        private User mainUser;
        public User MainUser
        {
            get { return mainUser; }
            set
            {
                mainUser = value;
                OnPropertyChanged(nameof(MainUser));
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
            }
        }

        private string currentBackground;
        public string CurrentBackground
        {
            get => currentBackground;
            set
            {
                if (currentBackground != value)
                {
                    currentBackground = value;
                    OnPropertyChanged(nameof(CurrentBackground)); 
                }
            }
        }

        // Команды для действий пользователя
        public ICommand WaterCommand { get; private set; }
        public ICommand FertilizeCommand { get; private set; }
        public ICommand TreatCommand { get; private set; }
        public ICommand SellPlantCommand { get; private set; }
        public PlantViewModel(User user)
        {
            this.MainUser = user;
            SelectedPlant = MainUser.Plants.First();
            UpdateBackground();

            // Инициализация команд
            WaterCommand = new RelayCommand(_ => WaterPlant(), _ => canWater);
            FertilizeCommand = new RelayCommand(_ => FertilizePlant(), _ => CanFertilizePlant());
            TreatCommand = new RelayCommand(_ => TreatPlant(), _ => CanTreatPlant());
            SellPlantCommand = new RelayCommand(PlantSellExecute, CanSellPlantExecute);

            // Настройка таймера для роста растения
            growthTimer = new DispatcherTimer();
            growthTimer.Interval = TimeSpan.FromSeconds(1);//TimeSpan.FromHours(1);
            growthTimer.Tick += GrowthTimer_Tick;
            growthTimer.Start();

            // Настройка таймера для тика растения
            tickTimer = new DispatcherTimer();
            tickTimer.Interval = TimeSpan.FromSeconds(1);//TimeSpan.FromHours(1);
            tickTimer.Tick += TickTimer_Tick;
            tickTimer.Start();

            // Настройка таймера задержки полива
            waterTimer = new DispatcherTimer();
            waterTimer.Interval = TimeSpan.FromSeconds(3);
            waterTimer.Tick += WaterTimer_Tick;

            //Таймер фона
            backgroundUpdateTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromHours(1) 
            };
            backgroundUpdateTimer.Tick += (s, e) => UpdateBackground();
            backgroundUpdateTimer.Start();
        }

        private void GrowthTimer_Tick(object sender, EventArgs e)
        {
            foreach (var plant in MainUser.Plants)
            {
                plant.Grow();
                plant.CheckPests(random.Next(100) < 3);
            }
            OnPropertyChanged(nameof(MainUser.Plants));
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            foreach (var plant in MainUser.Plants)
            {
                plant.Tick(random.Next(5)); 
            }
            OnPropertyChanged(nameof(MainUser.Plants));
        }

        private void WaterTimer_Tick(object sender, EventArgs e)
        {
            canWater = true; // Снова разрешаем полив после задержки
            waterTimer.Stop(); // Останавливаем таймер

            CommandManager.InvalidateRequerySuggested();
        }

        private void WaterPlant()
        {
            if (SelectedPlant != null)
            {
                SelectedPlant.Water(mainUser.WaterMultiplier);
                canWater = false;
                waterTimer.Start();
                CommandManager.InvalidateRequerySuggested();
            }
            this.MainUser.Money += 5;
        }

        private bool CanFertilizePlant()
        {
            return SelectedPlant != null && this.MainUser.Inventory.Any(i => i.IsFertilizer);
        }

        private void FertilizePlant()
        {
            if (SelectedPlant != null && this.MainUser.UseFertilizer())
            {
                SelectedPlant.Fertilize(); // Удобряем выбранное растение
            }
        }

        private bool CanTreatPlant()
        {
            return SelectedPlant != null && SelectedPlant.HasPests && this.MainUser.Inventory.Any(i => i.IsPestControl);
        }

        private void TreatPlant()
        {
            if (SelectedPlant != null && this.MainUser.UsePestControl())
            {
                SelectedPlant.RemovePests(); // Применяем средство против вредителей
            }
        }

        private void UpdateBackground()
        {
            CurrentBackground = converter.Convert(null, null, null, null) as string;
        }

        private bool CanSellPlantExecute(object parameter)
        {
            return parameter is Plant; // Проверка, что параметр - это растение
        }

        private void PlantSellExecute(object parameter)
        {
            if (parameter is Plant plant)
            {
                MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите продать {plant.Name}?", "Подтверждение продажи", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    MainUser.Money += plant.Price; // Увеличение баланса пользователя на стоимость растения
                    MainUser.Plants.Remove(plant); // Удаление растения из списка

                    OnPropertyChanged(nameof(MainUser.Money));
                    OnPropertyChanged(nameof(MainUser.Plants));
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
