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
        public Spell(string spellName = "", string spellDescription = "")
        {
            SpellName = spellName;
            SpellDescription = spellDescription;
        }

        public Spell()
        {
            SpellName = "";
            SpellDescription = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private String spellName = "SpellName";

        public String SpellName
        {
            get { return spellName; }
            set
            {
                spellName = value;
                FieldChanged();
            }
        }

        private String spellDescription = "SpellDescription";

        public String SpellDescription
        {
            get { return spellDescription; }
            set
            {
                spellDescription = value;
                FieldChanged();
            }
        }
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }
        public override string ToString()
        {
            return $"SpellName:{SpellName}\n" +
                $"SpellDescription:{SpellDescription}\n";
        }
    }
}
