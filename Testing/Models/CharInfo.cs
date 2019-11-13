using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class CharInfo
    {
        public CharInfo()
        {
            PlayerImageURI = "";
            Level = 0;
            Background = new String[5];
            Allignment = "";
            CurrentEXP = 0;
            GoalEXP = 0;
            Stats = new int[6];
            StatMods = new int[6];
            PlayerName = "";
            CharacterName = "";
            Title = "";
            Race = "";
            CharacterName = "";
        }

        private String playerImageURI;
        public String PlayerImageURI
        {
            get { return playerImageURI; }
            set { playerImageURI = value; }
        }

        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private String[] background;
        public String[] Background
        {
            get { return background; }
            set { background = value; }
        }


        private String allignment;
        public String Allignment
        {
            get { return allignment; }
            set { allignment = value; }
        }

        private int currentEXP;
        public int CurrentEXP
        {
            get { return currentEXP; }
            set { currentEXP = value; }
        }

        private int goalEXP;
        public int GoalEXP
        {
            get { return goalEXP; }
            set { goalEXP = value; }
        }

        private int[] stats;
        public int[] Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        private int[] statMods;
        public int[] StatMods
        {
            get { return statMods; }
            set { statMods = value; }
        }

        private String playerName;
        public String PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private String characterName;
        public String CharacterName
        {
            get { return characterName; }
            set { characterName = value; }
        }

        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String race;
        public String Race
        {
            get { return race; }
            set { race = value; }
        }

        private String characterClass;
        public String CharacterClass
        {
            get { return characterClass; }
            set { characterClass = value; }
        }
    }
}
