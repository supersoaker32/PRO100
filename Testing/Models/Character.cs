using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Character
    {
        public Character(CharInfo charactersInfo = null,  ActStats activeStats = null,List<Spell> spellbook = null, List<Feature> featureList = null, InventoryData inventory = null, SkillsAndProficienciesData snPData = null, int[] spellSlots = null, int spellMod = 0, int spellSave = 0)
        {
            CharactersInfo = (charactersInfo != null) ? charactersInfo : new CharInfo();
            ActiveStats = (activeStats != null) ? activeStats : new ActStats();
            Spellbook = (spellbook != null) ? spellbook : new List<Spell>();
            FeatureList = (featureList != null) ? featureList : new List<Feature>();
            Inventory = (inventory != null) ? inventory : new InventoryData();
            SnPData = (snPData != null) ? snPData : new SkillsAndProficienciesData();
            SpellSlots = (spellSlots != null) ? spellSlots : new int[9];
            SpellMod = spellMod;
            SpellSave = spellSave;
        }


        public Character()
        {
            CharactersInfo = new CharInfo();
            ActiveStats = new ActStats();
            Spellbook = new List<Spell>();
            FeatureList = new List<Feature>();
            Inventory = new InventoryData();
            SnPData = new SkillsAndProficienciesData();
            SpellSlots = new int[9];
            SpellMod = 0;
            SpellSave = 0;
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

        private int[] spellSlots;

        public int[] SpellSlots
        {
            get { return spellSlots; }
            set { spellSlots = value; }
        }

        private int spellSave;

        public int SpellSave
        {
            get { return spellSave; }
            set { spellSave = value; }
        }

        private int spellMod;

        public int SpellMod
        {
            get { return spellMod; }
            set { spellMod = value; }
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
