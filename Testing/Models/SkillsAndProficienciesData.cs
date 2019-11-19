using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class SkillsAndProficienciesData
    {
        public SkillsAndProficienciesData(List<string> proficiencies = null, Skill[] skillModifiers = null)
        {
            Proficiencies = (proficiencies != null) ? proficiencies : new List<string>();
            SkillModifiers = (skillModifiers != null) ? skillModifiers : new Skill[17];
        }

        public SkillsAndProficienciesData()
        {
            Proficiencies = new List<string>();
            SkillModifiers = new Skill[17];
        }
        private List<String> proficiencies = new List<string>();
        public List<String> Proficiencies
        {
            get { return proficiencies; }
            set { proficiencies = value; }
        }

        private Skill[] skillModifiers = new Skill[17];

        public Skill[] SkillModifiers
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
            foreach(Skill skillModifier in SkillModifiers)
            {
                toString = toString + $"{skillModifier.ToString()}";
            }

            return toString;
        }
        private Skill[] savingThrows = new Skill[6];
        public Skill[] SavingThrows
        {
            get { return savingThrows; }
            set { savingThrows = value; }
        }
    }
}
