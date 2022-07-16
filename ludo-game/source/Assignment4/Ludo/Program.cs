using System;

namespace Ludo
{
    class Program
    {
        static void Main(string[] args)
        {
            Home<string> home = new Home<string>();
            Player<string, int> participants = new Player<string, int>();
            Game game = new Game();
        }
    }
}
