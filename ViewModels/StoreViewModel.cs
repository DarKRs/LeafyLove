using LeafyLove.Domain.Models;
using LeafyLove.Models;
using LeafyLove.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeafyLove.ViewModels
{
    public class StoreViewModel : INotifyPropertyChanged
    {
        private User _user;
        public User MainUser
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(MainUser));
                }
            }
        }
        public ObservableCollection<StoreItem> FlowerItems { get; set; }
        public ObservableCollection<StoreItem> ToolItems { get; set; }

        public ICommand PurchaseCommand { get; private set; }

        // Конструктор
        public StoreViewModel(User _user)
        {
            MainUser = _user;
            FlowerItems = new ObservableCollection<StoreItem>
            {
                new StoreItem
                {
                    Name = "Цветок",
                    Price = 50,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Mature.png",
                    IsPlant = true,
                    PlantType = typeof(Plant)
                },
                new StoreItem
                {
                    Name = "Роза",
                    Price = 100,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Rose/RoseMature.png",
                    IsPlant = true,
                    PlantType = typeof(Rose)
                },
                new StoreItem
                {
                    Name = "Тюльпан",
                    Price = 75,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Tulip/TulipMature.png",
                    IsPlant = true,
                    PlantType = typeof(Tulip)
                },
                new StoreItem
                {
                    Name = "Гипсофилы",
                    Price = 75,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Gypsophila/GypsophilaMature.png",
                    IsPlant = true,
                    PlantType = typeof(Gypsophila)
                },
                new StoreItem
                {
                    Name = "Лего цветок",
                    Price = 75,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Lego/LegoMature.png",
                    IsPlant = true,
                    PlantType = typeof(LegoPlant)
                },
                new StoreItem
                {
                    Name = "Лилии",
                    Price = 75,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Lilies/LiliesMature.png",
                    IsPlant = true,
                    PlantType = typeof(Lilies)
                },
            };

            ToolItems = new ObservableCollection<StoreItem>
            {
                new StoreItem
                {
                    Name = "Удобрение",
                    Price = 50,
                    ImagePath = "pack://application:,,,/Images/Fertilizer.png"
                }
            };

            PurchaseCommand = new RelayCommand(ExecutePurchase, CanExecutePurchase);
        }


        // Реализация методов
        private void ExecutePurchase(object parameter)
        {
            if (parameter is StoreItem item && item.IsPlant)
            {
                if (MainUser.Money >= item.Price)
                {
                    MainUser.Money -= item.Price;

                    var plant = (Plant)Activator.CreateInstance(item.PlantType, new object[] { item.Name });
                    MainUser.Plants.Add(plant);
                }
                else
                {
                    // Сообщаем, что недостаточно средств
                }
            }
        }

        private bool CanExecutePurchase(object parameter)
        {
            // Проверка условий покупки
            return true; // Или логика проверки
        }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
