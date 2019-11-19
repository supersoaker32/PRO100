using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class ActStats
    {
        public ActStats(byte success_SavingThrows = 0, byte failure_SavingThrows = 0, int initiative = 0, int speed = 0, int armorClass = 0, int maxHP = 0, int tempHP = 0, int currentHP = 0)
        {
            Success_SavingThrows = success_SavingThrows;
            Failure_SavingThrows = failure_SavingThrows;
            Initiative = initiative;
            Speed = speed;
            ArmorClass = armorClass;
            MaxHP = maxHP;
            TempHP = tempHP;
            CurrentHP = currentHP;
        }
        public ActStats()
        {
            Success_SavingThrows = 0;
            Failure_SavingThrows = 0;
            Initiative = 0;
            Speed = 0;
            ArmorClass = 0;
            MaxHP = 0;
            TempHP = 0;
            CurrentHP = 0;
        }
        private byte success_SavingThrows;

        public byte Success_SavingThrows
        {
            get { return success_SavingThrows; }
            set { success_SavingThrows = value; }
        }

        private byte failure_SavingThrows;

        public byte Failure_SavingThrows
        {
            get { return failure_SavingThrows; }
            set { failure_SavingThrows = value; }
        }

        private int initiative;

        public int Initiative
        {
            get { return initiative; }
            set { initiative = value; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private int armorClass;

        public int ArmorClass
        {
            get { return armorClass; }
            set { armorClass = value; }
        }

        private int maxHP;

        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        private int tempHP;

        public int TempHP
        {
            get { return tempHP; }
            set { tempHP = value; }
        }

        private int currentHP;

        public int CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value; }
        }
    }
}
