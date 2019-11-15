using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class CharInfo
    {


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

        public CharInfo(string playerImageURI = "", int level = 1, string[] background = null, string allignment = "", int currentEXP = 0, int goalEXP = 350, int[] stats = null, int[] statMods = null, string playerName = "", string characterName = "", string title = "", string race = "", string characterClass = "")
        {
            PlayerImageURI = playerImageURI;
            Level = level;
            Background = (background != null) ? background : new string[5];
            Allignment = allignment;
            CurrentEXP = currentEXP;
            GoalEXP = goalEXP;
            Stats = (stats != null) ? stats : new int[6];
            StatMods = (statMods != null) ? statMods : new int[6];
            PlayerName = playerName;
            CharacterName = characterName;
            Title = title;
            Race = race;
            CharacterClass = characterClass;
        }

        public String CharacterClass
        {
            get { return characterClass; }
            set { characterClass = value; }
        }
    }
}
