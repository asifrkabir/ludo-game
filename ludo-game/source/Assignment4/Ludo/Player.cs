using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class Player<T, V> : Dice<int> 
                                where T : class 
                                where V : struct 
    {
        public T Name { get; set; }
        public T Color { get; set; }
        public V[] PawnIndex { get; set; }
        public V index;
        public IDice DiceMode;

        public Player()
        {
            Name = default(T);
            Color = default(T);
            index = default(V);
        }
    }
}
