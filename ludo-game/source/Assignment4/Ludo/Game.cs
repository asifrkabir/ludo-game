using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class Game : IGame, IPlayer
    {
        public int PlayerNumber { get; set; }
        delegate int method();
        static event Action<string> Subscribe;
        public Player<string, int>[] Contestants;
        public bool MatchOn = true;
        public int Value;
        public int LargestDiceSide;
        public int DiceInput { get; set; }
        public IDice DiceInstance { get; set; }

        public Game()
        {
            Contestants = new Player<string, int>[4];
            method setPlayer = SetPlayers;
            AssignPlayers(setPlayer());
            ShowPlayerDetails();
            Console.WriteLine("\n\n\n");
            EnterDiceAmount();
            GameSessionStart();
        }

        public void EnterDiceAmount()
        {
            string[] paragraph3 = File.ReadAllLines("message/dice.txt");

            foreach(var lines in paragraph3)
            {
                Console.WriteLine(lines);
            }

            DiceInput = int.Parse(Console.ReadLine());

            if (DiceInput == 1)
            {
                DiceInstance = new SixSidedDice();
                LargestDiceSide = 6;
            }
                
            else if (DiceInput == 2)
            {
                DiceInstance = new EightSidedDice();
                LargestDiceSide = 6;
            }   
        }

        public int SetPlayers()
        {
            return PlayerNumber = int.Parse(Console.ReadLine());
        }

        public void AssignPlayers(in int PlayerNumber)
        {
            Console.WriteLine("Please Enter Player Name One At A Time!");

            if (PlayerNumber == 2)
            {
                PlayerTwo();
            }

            else if (PlayerNumber == 3)
            {
                PlayerThree();
            }

            else if (PlayerNumber == 4)
            {
                PlayerFour();
            }
        }

        public void PlayerTwo()
        {
            Contestants[0] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Red", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Contestants[1] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Blue", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Subscribe += PlayerOne;
            Subscribe += PlayerTwo;
        }

        public void PlayerThree()
        {
            Contestants[0] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Red", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Contestants[1] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Blue", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Contestants[2] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Green", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Subscribe += PlayerOne;
            Subscribe += PlayerTwo;
            Subscribe += PlayerThree;
        }

        public void PlayerFour()
        {
            Contestants[0] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Red", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Contestants[1] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Blue", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Contestants[2] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Green", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Contestants[3] = new Player<string, int>() { Name = Console.ReadLine(), Color = "Yellow", PawnIndex = new int[4], index = 0, DiceMode = DiceInstance };
            Subscribe += PlayerOne;
            Subscribe += PlayerTwo;
            Subscribe += PlayerThree;
            Subscribe += PlayerFour;
        }

        public void ShowPlayerDetails()
        {
            Subscribe.Invoke("is ready for the game");
        }

        public void PlayerOne(string recipient)
        {
            Console.WriteLine($"Player one {Contestants[0].Name}({Contestants[0].Color}) {recipient}");
        }

        public void PlayerTwo(string recipient)
        {
            Console.WriteLine($"Player two {Contestants[1].Name}({Contestants[1].Color}) {recipient}");
        }

        public void PlayerThree(string recipient)
        {
            Console.WriteLine($"Player three {Contestants[2].Name}({Contestants[2].Color}) {recipient}");
        }

        public void PlayerFour(string recipient)
        {
            Console.WriteLine($"Player four {Contestants[3].Name}({Contestants[3].Color}) {recipient}");
        }

        public void GameSessionStart()
        {
            while (MatchOn)
            {
                int i = 0;

                while(i < PlayerNumber)
                {
                    Console.WriteLine($"{Contestants[i].Name} ROLLING DICE.");
                    Console.WriteLine("PLEASE PRESS ENTER TO ROLL");
                    Console.ReadKey();
                    Value = Contestants[i].Roll();
                    Console.WriteLine($"{Contestants[i].Name} GOT {Value}.");
                    CheckUnlock(ref Contestants[i], Value);
                    i++;
                }
            }
        }

        public void CheckUnlock(ref Player<string, int> player, int Value)
        {
            string unlock;
            if(Value == LargestDiceSide)
            {
                Console.WriteLine("DO YOU WANT TO UNLOCK THE PAWN? PRESS y to UNLOCK and n to SKIP");
                unlock = Console.ReadLine();

                if(unlock.Equals("y"))
                {
                    Console.WriteLine("PLEASE PRESS ENTER AGAIN TO ROLL");
                    Console.ReadKey();
                    Value = player.Roll();
                    Console.WriteLine($"{player.Name} GOT {Value}.");
                    player.PawnIndex[player.index] += Value;
                    Console.WriteLine($"{player.Name} PAWN {player.index + 1} moved by {player.PawnIndex[player.index]}");
                    player.index++;
                }
               
            }

            else if(player.index > 0)
            {
                player.PawnIndex[player.index] += Value;
                Console.WriteLine($"{player.Name} PAWN {player.index} moved by {player.PawnIndex[player.index]}");
            }
        }
    }
}
