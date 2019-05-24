using System;
using System.Collections.Generic;
using ChessApp.CheckMovesStrategy;
using ChessApp.Models.Chessboard;

namespace ChessApp.Models.Pieces
{
    internal class RookCheckStrategy : ValidateMethod, ICheckStrategy
    {
        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            List<string> possibleMovies = new List<string>();

            possibleMovies.AddRange(CheckQuarter(1, 0, position, chessboard));
            possibleMovies.AddRange(CheckQuarter(-1, 0, position, chessboard));
            possibleMovies.AddRange(CheckQuarter(0, -1, position, chessboard));
            possibleMovies.AddRange(CheckQuarter(0, 1, position, chessboard));

            return possibleMovies;
        }
    }
}
