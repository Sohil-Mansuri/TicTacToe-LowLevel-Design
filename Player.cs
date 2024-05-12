using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLowLevelDesign
{
    public class Player
    {
        public Player(string name, PlayingPiece playingPiece)
        {
            Name = name;
            PlayingPiece = playingPiece;
        }

        public string Name { get; set; }

        public PlayingPiece PlayingPiece { get; set; }
    }
}
