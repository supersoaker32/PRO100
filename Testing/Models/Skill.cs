using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Skill : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int modifier = 0;

        public Skill()
        {
            Modifier = 0;
            Proficient = false;
            Name = "";
        }

        public Skill(string name, int mod = 0, bool proficient = false)
        {
            Modifier = mod;
            Proficient = proficient;
            Name = name;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }

        private bool proficient = false;

        public bool Proficient
        {
            get { return proficient; }
            set 
            { 
                proficient = value;
                FieldChanged();
            }
        }
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

    }
}
