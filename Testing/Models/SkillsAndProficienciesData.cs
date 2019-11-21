using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class SkillsAndProficienciesData
    {
        public SkillsAndProficienciesData(List<string> proficiencies = null, int[] skillModifiers = null, bool[] savingBools = null, bool[] skillBools = null)
        {
            Proficiencies = (proficiencies != null) ? proficiencies : new List<string>();
            SkillModifiers = (skillModifiers != null) ? skillModifiers : new int[17];
            SavingBools = (savingBools != null) ? savingBools : new bool[6];
            SkillBools = (skillBools != null) ? skillBools : new bool[18];
        }

        public SkillsAndProficienciesData()
        {
            Proficiencies = new List<string>();
            SkillModifiers = new int[17];
            SavingBools = new bool[6];
            SkillBools = new bool[18];
        }
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
        public override string ToString()
        {
            string toString = "";
            foreach(String proficiency in Proficiencies)
            {
                toString = toString + $"{proficiency}\n";
            }
            foreach(int skillModifier in SkillModifiers)
            {
                toString = toString + $"{skillModifier.ToString()}";
            }

            return toString;
        }
        private int[] savingThrows = new int[6];
        public int[] SavingThrows
        {
            get { return savingThrows; }
            set { savingThrows = value; }
        }

        private bool[] savingBools;
        public bool[] SavingBools
        {
            get { return savingBools; }
            set { savingBools = value; }
        }

        private bool[] skillBools;
        public bool[] SkillBools
        {
            get { return skillBools; }
            set { skillBools = value; }
        }
    }
}
