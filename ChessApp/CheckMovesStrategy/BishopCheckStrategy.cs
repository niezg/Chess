using ChessApp.Models.Chessboard;
using System;
using System.Collections.Generic;

namespace ChessApp.Models.Pieces
{
    public class BishopCheckStrategy : ICheckStrategy
    {
        private readonly ValidateMethod validateMethod;

        public BishopCheckStrategy()
        {
            validateMethod = new ValidateMethod();
        }

        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            List<string> possibleMovies = new List<string>();

            possibleMovies.AddRange(validateMethod.CheckQuarter(1, 1, position, chessboard));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, 1, position, chessboard));
            possibleMovies.AddRange(validateMethod.CheckQuarter(-1, -1, position, chessboard));
            possibleMovies.AddRange(validateMethod.CheckQuarter(1, -1, position, chessboard));

            return possibleMovies;
        }
    }
}