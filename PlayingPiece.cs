using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLowLevelDesign
{
    public class PlayingPiece
    {
        public PlayingPiece(PieceType pieceType)
        {
            PieceType = pieceType;
        }

        public PieceType PieceType { get; set; }
    }
}
