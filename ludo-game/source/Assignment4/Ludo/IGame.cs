using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public interface IGame
    {
        public void EnterDiceAmount();
        public int SetPlayers();
        public void AssignPlayers(in int PlayerNumber);
        public void GameSessionStart();
        public void CheckUnlock(ref Player<string, int> player, int Value);
    }
}
