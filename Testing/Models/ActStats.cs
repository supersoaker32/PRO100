using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    class ActStats
    {
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

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


    }
}
