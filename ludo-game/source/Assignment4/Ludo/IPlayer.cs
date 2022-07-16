using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public interface IPlayer
    {
        public int SetPlayers();
        public void AssignPlayers(in int PlayerNumber);
        public void PlayerTwo();
        public void PlayerThree();
        public void PlayerFour();
        public void ShowPlayerDetails();
        public void PlayerOne(string recepient);
        public void PlayerTwo(string recepient);
        public void PlayerThree(string recepient);
        public void PlayerFour(string recepient);
    }
}
