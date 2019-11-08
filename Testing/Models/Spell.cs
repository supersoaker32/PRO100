using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Spell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String spellName;
        private String description;

        public String SpellName
        {
            get { return spellName; }
            set 
            { 
                spellName = value;
                FieldChanged();
            }
        }

        public String Description
        {
            get { return description; }
            set
            {
                description = value;
                FieldChanged();
            }
        }


        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }

    }
}
