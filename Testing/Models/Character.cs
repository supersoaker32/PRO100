﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Character
    {
        public Character()
        {
            CharactersInfo = new CharInfo();
            Spellbook = new List<Spell>();
            Inventory = new InventoryData();
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

        private InventoryData inventory;
        public InventoryData Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
    }
}