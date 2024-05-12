using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLowLevelDesign
{
    internal class PlayingBoard
    {
        private readonly string[,] _board;
        public PlayingBoard(int size)
        {
            _board = new string[size, size];
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    Console.Write(_board[i, j] + "  |  ");
                }

                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public bool IsLocationFilled(int row, int column)
        {
            return !string.IsNullOrEmpty(_board[row, column]);
        }


        public bool Add(int row, int column, string value)
        {
            if (string.IsNullOrEmpty(_board[row, column]))
            {
                _board[row, column] = value;
                return true;
            }

            return false;
        }

        public bool IsBoardEmpty()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (string.IsNullOrEmpty(_board[i, j]))
                        return true;
                }
            }

            return false;
        }

        public bool IsWinner(int row, int column, string value)
        {
            bool isRowMatched = true;
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                if (string.IsNullOrEmpty(_board[row, i]) || _board[row, i] != value)
                    isRowMatched = false;
            }

            if (isRowMatched) return true;
            
            bool isColumnMatched = true;
            for (int i = 0; i < _board.GetLength(1); i++)
            {
                if (string.IsNullOrEmpty(_board[i, column]) || _board[i, column] != value)
                    isColumnMatched = false;
            }

            if(isColumnMatched) return true;

            //match diagonals 
            bool isDiagonalMatch = true;
            for (int i = 0, j = 0; i < _board.GetLength(0); i++,j++)
            {
                if (string.IsNullOrEmpty(_board[i, j]) || _board[i, j] != value)
                    isDiagonalMatch = false;
            }

            if (isDiagonalMatch) return true;

            return false;
        }
    }
}
