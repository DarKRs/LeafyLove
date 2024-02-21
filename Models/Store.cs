using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafyLove.Models
{
    public class StoreItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class Store
    {
        public List<StoreItem> Items { get; private set; }

        public Store()
        {
            Items = new List<StoreItem>();
            // Инициализация начальных предметов магазина
        }

        public void AddItem(StoreItem item)
        {
            Items.Add(item);
        }

        public void PurchaseItem(User user, StoreItem item)
        {
            if (user.Money >= item.Price)
            {
                user.Money -= item.Price;
                // Логика после покупки предмета (например, добавление удобрения в инвентарь)
            }
        }
    }
}
