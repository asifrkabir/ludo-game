using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public abstract class Dice<V> : IDice
    {
        public V DiceValue { get; set; }
        public Random rand;

        public Dice()
        {
            dynamic diceValue = (int)SideDice.DiceFullSide;
            DiceValue = diceValue;
            rand = new Random();
        }

        public virtual int Roll()
        {
            return rand.Next((int)SideDice.DiceStart, (int)SideDice.DiceEnd);
        }
    }

    public enum SideDice
    {
        DiceStart = 1,
        DiceFullSide = 6,
        DiceEnd = 7
    }
}
