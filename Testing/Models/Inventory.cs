using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class InventoryData
    {
        private List<Item> items;
        private int[] money;

        public InventoryData(int[] money = null, List<Item> items = null)
        {
            Money = (money != null) ? money : new int[5];
            Items = (items != null) ? items : new List<Item>();
        }

        public int[] Money
        {
            get { return money; }
            set { money = value; }
        }


        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

    }
}
