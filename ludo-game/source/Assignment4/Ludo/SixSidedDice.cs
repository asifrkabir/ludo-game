using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class SixSidedDice : Dice<int>, IDice
    {
        public SixSidedDice()
        {
            DiceValue = (int)SixSideDice.DiceFullSide;
        }

        public sealed override int Roll()
        {
            return rand.Next((int)SixSideDice.DiceStart, (int)SixSideDice.DiceEnd);
        }
    }

    public enum SixSideDice
    {
        DiceStart = 1,
        DiceFullSide = 6,
        DiceEnd = 7
    }
}
