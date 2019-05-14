using System;
using System.Collections.Generic;
using ChessApp.Models.Chessboard;

namespace ChessApp.Models.Pieces
{
    internal class KingCheckStrategy : ICheckStrategy
    {
        private readonly ValidateMethod validateMethod;

        public KingCheckStrategy()
        {
            validateMethod = new ValidateMethod();
        }

        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            List<string> possibleMovies = new List<string>();

            possibleMovies.AddRange(validateMethod.CheckQuarter(1, 0, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, 0, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(0, -1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(0, 1, position, chessboard, false));

            possibleMovies.AddRange(validateMethod.CheckQuarter(1, 1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, 1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, -1, position, chessboard, false));
            possibleMovies.AddRange(validateMethod.CheckQuarter(1, -1, position, chessboard, false));

            return possibleMovies;
        }

    }
}
