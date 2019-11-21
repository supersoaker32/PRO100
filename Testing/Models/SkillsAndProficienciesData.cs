using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class SkillsAndProficienciesData
    {
        public Skill[] InitializeSkills()
        {
            Skill[] skills = new Skill[18];
            skills[0] = new Skill("Acrobatics");
            skills[1] = new Skill("AnimalHandling");
            skills[2] = new Skill("Arcana");
            skills[3] = new Skill("Athletics");
            skills[4] = new Skill("Deception");
            skills[5] = new Skill("History");
            skills[6] = new Skill("Insight");
            skills[7] = new Skill("Intimidation");
            skills[8] = new Skill("Investigation");
            skills[9] = new Skill("Medicine");
            skills[10] = new Skill("Nature");
            skills[11] = new Skill("Perception");
            skills[12] = new Skill("Performance");
            skills[13] = new Skill("Persuassion");
            skills[14] = new Skill("Religion");
            skills[15] = new Skill("Sleight Of Hand");
            skills[16] = new Skill("Stealth");
            skills[17] = new Skill("Survival");
            return skills;
        }

        public Skill[] InitializeSaves()
        {
            Skill[] skills = new Skill[6];
            skills[0] = new Skill("Strength");
            skills[1] = new Skill("Dexterity");
            skills[2] = new Skill("Constitution");
            skills[3] = new Skill("Intelligence");
            skills[4] = new Skill("Wisdom");
            skills[5] = new Skill("Charisma");
            return skills;
        }
        public SkillsAndProficienciesData(List<string> proficiencies = null, Skill[] skills = null, Skill[] savingThrows = null)
        {
            Proficiencies = (proficiencies != null) ? proficiencies : new List<string>();
            SkillModifiers = (skills != null) ? skills : InitializeSkills();
            SavingThrows = (savingThrows != null) ? savingThrows : InitializeSaves();
        }

        public SkillsAndProficienciesData()
        {
            Proficiencies = new List<string>();
            SkillModifiers = InitializeSkills();
            SavingThrows = InitializeSaves();
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
