using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class EightSidedDice : Dice<int>, IDice
    {
        public EightSidedDice()
        {
            DiceValue = (int)EightSideDice.DiceFullSide;
        }

        public sealed override int Roll()
        {
            return rand.Next((int)EightSideDice.DiceStart, (int)EightSideDice.DiceEnd);
        }
    }

    public enum EightSideDice
    {
        DiceStart = 7,
        DiceFullSide = 8,
        DiceEnd = 9
    }
}
