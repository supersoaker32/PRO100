using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Character
    {
        public Character(CharInfo charactersInfo = null,  ActStats activeStats = null,List<Spell> spellbook = null, List<Feature> featureList = null, InventoryData inventory = null, SkillsAndProficienciesData snPData = null)
        {
            CharactersInfo = (charactersInfo != null) ? charactersInfo : new CharInfo();
            ActiveStats = (activeStats != null) ? activeStats : new ActStats();
            Spellbook = (spellbook != null) ? spellbook : new List<Spell>();
            FeatureList = (featureList != null) ? featureList : new List<Feature>();
            Inventory = (inventory != null) ? inventory : new InventoryData();
            SnPData = (snPData != null) ? snPData : new SkillsAndProficienciesData();
        }

        public Character()
        {
            CharactersInfo = new CharInfo();
            ActiveStats = new ActStats();
            Spellbook = new List<Spell>();
            FeatureList = new List<Feature>();
            Inventory = new InventoryData();
            SnPData = new SkillsAndProficienciesData();
        }

        private CharInfo charactersInfo;
        public CharInfo CharactersInfo
        {
            get { return charactersInfo; }
            set { charactersInfo = value; }
        }

        private ActStats activeStats;

        public ActStats ActiveStats
        {
            get { return activeStats; }
            set { activeStats = value; }
        }


        private List<Spell> spellbook;
        public List<Spell> Spellbook
        {
            get { return  spellbook; }
            set {  spellbook = value; }
        }

        private List<Feature> featureList;
        public List<Feature> FeatureList
        {
            get { return featureList; }
            set { featureList = value; }
        }

        private InventoryData inventory;
        public InventoryData Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        private SkillsAndProficienciesData snpData;

        public SkillsAndProficienciesData SnPData
        {
            get { return snpData; }
            set { snpData = value; }
        }

        public override string ToString()
        {
            string toString = $"{CharactersInfo.ToString()}|{Spellbook.ToString()}|";
            foreach (Spell spell in Spellbook)
            {
                toString = toString + $"{spell}|";
            }
            foreach (Feature feature in FeatureList)
            {
                toString = toString + $"{feature}|";
            }
            toString = toString + $"{Inventory}|{SnPData}";
            return toString;
        }
    }
}
