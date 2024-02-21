using LeafyLove.Domain.Models;
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
        private DispatcherTimer growthTimer;

        private Plant plant;

        public Plant Plant
        {
            get { return plant; }
            set
            {
                plant = value;
                OnPropertyChanged(nameof(Plant));
            }
        }

        // Команды для действий пользователя
        public ICommand WaterCommand { get; private set; }
        public ICommand FertilizeCommand { get; private set; }
        public ICommand TreatCommand { get; private set; }
        public ICommand OpenStoreCommand { get; private set; }

        public PlantViewModel()
        {
            Plant = new Plant("Ваше растение");

            // Инициализация команд
            WaterCommand = new RelayCommand(o => Plant.Water(), o => Plant.Health < 100);
            FertilizeCommand = new RelayCommand(o => Plant.Fertilize());
            TreatCommand = new RelayCommand(o => Plant.RemovePests(), o => Plant.HasPests);

            // Настройка таймера для роста растения
            growthTimer = new DispatcherTimer();
            growthTimer.Interval = TimeSpan.FromSeconds(1);//TimeSpan.FromHours(1); // Установите интервал в соответствии с желаемой скоростью роста
            growthTimer.Tick += GrowthTimer_Tick;
            growthTimer.Start();
        }

        private void GrowthTimer_Tick(object sender, EventArgs e)
        {
            Plant.Grow();
            Plant.CheckPests(); // Проверьте наличие вредителей при каждом тике таймера
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
