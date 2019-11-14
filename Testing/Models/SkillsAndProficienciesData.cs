using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class SkillsAndProficienciesData
    {
        private List<String> proficiencies = new List<string>();

        public List<String> Proficiencies
        {
            get { return proficiencies; }
            set { proficiencies = value; }
        }

        private int[] skillModifiers = new int[17];

        public int[] SkillModifiers
        {
            get { return skillModifiers; }
            set { skillModifiers = value; }
        }
    }
}
