using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Skill
    {


        private int modifier;

        public Skill()
        {
            modifier = 0;
            Proficient = false;
        }

        public int Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }
        public bool Proficient { get; set; }
    }
}
