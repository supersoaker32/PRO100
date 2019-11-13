using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private string description = "";

        public Item(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                FieldChanged();
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                FieldChanged();
            }

        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }


    }
}
