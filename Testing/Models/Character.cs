using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Character
    {
        public Character(CharInfo charactersInfo = null, List<Spell> spellbook = null, List<Feature> featureList = null, InventoryData inventory = null, SkillsAndProficienciesData snPData = null)
        {
            CharactersInfo = (charactersInfo != null) ? charactersInfo : new CharInfo();
            Spellbook = (spellbook != null) ? spellbook : new List<Spell>();
            FeatureList = (featureList != null) ? featureList : new List<Feature>();
            Inventory = (inventory != null) ? inventory : new InventoryData();
            SnPData = (snPData != null) ? snPData : new SkillsAndProficienciesData();
        }

        private CharInfo charactersInfo;
        public CharInfo CharactersInfo
        {
            get { return charactersInfo; }
            set { charactersInfo = value; }
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


    }
}
