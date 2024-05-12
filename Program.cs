using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLowLevelDesign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame("Player1", "Player2", 3);
            game.StartGame();
            Console.ReadKey();
        }
    }
}
