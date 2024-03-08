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

        private int waterUpgradeMultiplier = 1;

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
                    Price = 20,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Mature.png",
                    IsPlant = true,
                    PlantType = typeof(Plant)
                },
                new StoreItem
                {
                    Name = "Гвоздики",
                    Price = 30,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Cloves/ClovesMature.png",
                    IsPlant = true,
                    PlantType = typeof(Cloves)
                },
                new StoreItem
                {
                    Name = "Тюльпан",
                    Price = 45,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Tulip/TulipMature.png",
                    IsPlant = true,
                    PlantType = typeof(Tulip)
                },
                new StoreItem
                {
                    Name = "Роза",
                    Price = 80,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Rose/RoseMature.png",
                    IsPlant = true,
                    PlantType = typeof(Rose)
                },
                new StoreItem
                {
                    Name = "Лилии",
                    Price = 115,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Lilies/LiliesMature.png",
                    IsPlant = true,
                    PlantType = typeof(Lilies)
                },
                new StoreItem
                {
                    Name = "Гипсофилы",
                    Price = 150,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Gypsophila/GypsophilaMature.png",
                    IsPlant = true,
                    PlantType = typeof(Gypsophila)
                },
                new StoreItem
                {
                    Name = "Лего цветок",
                    Price = 200,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Plants/Lego/LegoMature.png",
                    IsPlant = true,
                    PlantType = typeof(LegoPlant)
                },
            };

            ToolItems = new ObservableCollection<StoreItem>
            {
                new StoreItem
                {
                    Name = "Улучшение лейки",
                    Price = 20 * waterUpgradeMultiplier,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/WaterUpgrade.png",
                    IsWaterUpgrade = true,
                },
                new StoreItem
                {
                    Name = "Удобрение",
                    Price = 50,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/Fertilizer.png",
                    IsFertilizer = true,
                },
                new StoreItem
                {
                    Name = "Средство от вредителей",
                    Price = 50,
                    ImagePath = "pack://application:,,,/LeafyLove;component/Resources/Images/PestDestroyer.png",
                    IsPestControl = true,
                }
            };

            PurchaseCommand = new RelayCommand(ExecutePurchase, CanExecutePurchase);
        }


        // Реализация методов
        private void ExecutePurchase(object parameter)
        {
            if (parameter is StoreItem item)
            {
                if (MainUser.Money >= item.Price && (item.IsFertilizer || item.IsPestControl))
                {
                    MainUser.Money -= item.Price;
                    MainUser.AddToInventory(item); // Добавляем удобрение в инвентарь пользователя
                    OnPropertyChanged(nameof(MainUser.Money));
                    OnPropertyChanged(nameof(MainUser.Inventory));
                }
                else if (MainUser.Money >= item.Price && item.IsWaterUpgrade)
                {
                    MainUser.Money -= item.Price;
                    MainUser.WaterMultiplier += 1;
                    waterUpgradeMultiplier += MainUser.WaterMultiplier;
                    ToolItems[0].Price = 20 * waterUpgradeMultiplier;
                    OnPropertyChanged(nameof(ToolItems));
                    OnPropertyChanged(nameof(MainUser.Money));
                }
                else if (_user.Money >= item.Price && item.IsPlant)
                {
                    MainUser.Money -= item.Price;

                    var plant = (Plant)Activator.CreateInstance(item.PlantType, new object[] { item.Name });
                    MainUser.Plants.Add(plant);
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
