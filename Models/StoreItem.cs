using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class StoreItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private int price;

        public int Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public string ImagePath { get; set; }
        public bool IsPlant { get; set; }
        public Type PlantType { get; set; }
        public bool IsFertilizer { get; set; }
        public bool IsPestControl { get; set; }
        public bool IsWaterUpgrade { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
