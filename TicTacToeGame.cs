using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLowLevelDesign
{
    public class TicTacToeGame
    {
        private readonly int _sizeOfBoard;
        private readonly List<Player> _players;
        private readonly PlayingBoard _playingBoard;

        public TicTacToeGame(string firstPalyerName, string secondPlayerName, int sizeOfBoard)
        {

            _players = new List<Player>();

            //Creating Player 1 
            PlayingPieceX playingPieceX = new PlayingPieceX();
            Player firstPlayer = new Player(firstPalyerName, playingPieceX);

            //Creating player 2
            PlayingPieceO playingPieceO = new PlayingPieceO();
            Player secondPalyer = new Player(secondPlayerName, playingPieceO);

            _players.Add(firstPlayer);
            _players.Add(secondPalyer);

            _sizeOfBoard = sizeOfBoard;
            _playingBoard = new PlayingBoard(_sizeOfBoard);
        }


        public void StartGame()
        {
            bool isGameOver = false;
            _playingBoard.DisplayBoard();

            while (!isGameOver)
            {
                if (!_playingBoard.IsBoardEmpty())
                {
                    isGameOver = true;
                    Console.WriteLine("Game is tie");
                    continue;
                }

                var currentPlayerTurn = _players[0];

                Console.WriteLine($"{currentPlayerTurn.Name} turn : Enter row, Enter column");
                string enteredPosition = Console.ReadLine();

                if (!string.IsNullOrEmpty(enteredPosition))
                {
                    var boardLocations = enteredPosition.Split(',');

                    if (boardLocations.Length != 2)
                    {
                        Console.WriteLine("Please Enter Valid location or in valid format");
                        continue;
                    }
                    else
                    {
                        int xLocationIndex = Convert.ToInt32(boardLocations[0]);
                        int yLocationIndex = Convert.ToInt32(boardLocations[1]);

                        if (xLocationIndex < 0 || yLocationIndex < 0 || xLocationIndex >= _sizeOfBoard || yLocationIndex >= _sizeOfBoard)
                        {
                            Console.WriteLine("Location is not valid");
                            continue;
                        }

                        if (!_playingBoard.Add(xLocationIndex, yLocationIndex, currentPlayerTurn.PlayingPiece.PieceType.ToString()))
                        {
                            Console.WriteLine("Entered location already filled");
                            continue;
                        }

                        _playingBoard.DisplayBoard();

                        if (_playingBoard.IsWinner(xLocationIndex, yLocationIndex, currentPlayerTurn.PlayingPiece.PieceType.ToString()))
                        {
                            isGameOver = true;
                            Console.WriteLine($"{currentPlayerTurn.Name} is winner");
                            break;
                        }
                        _players.RemoveAt(0);
                        _players.Add(currentPlayerTurn);
                    }
                }
            }
        }
    }
}
