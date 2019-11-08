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

        public InventoryData()
        {
            items = new List<Item>();
            money = new int[4];
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
