using System;
using System.Collections.Generic;
using ChessApp.Models.Chessboard;

namespace ChessApp.Models.Pieces
{
    internal class KnightCheckStrategy : ICheckStrategy
    {
        private readonly ValidateMethod validateMethod;

        public KnightCheckStrategy()
        {
            validateMethod = new ValidateMethod();
        }

        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            List<string> possibleMovies = new List<string>();

            possibleMovies.AddRange(validateMethod.CheckQuarter(1, 2, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, 2, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(2, -1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(2, 1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-2, 1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-2, -1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, -2, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(1, -2, position, chessboard, false));

            return possibleMovies;
        }
    }
}
