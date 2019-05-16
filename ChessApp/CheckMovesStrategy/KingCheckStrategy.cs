using System;
using System.Collections.Generic;
using ChessApp.CheckMovesStrategy;
using ChessApp.Models.Chessboard;

namespace ChessApp.Models.Pieces
{
    internal class KingCheckStrategy : ICheckStrategy, IDifferentFirstMove
    {
        private readonly ValidateMethod validateMethod;
        public bool IsFirstMove { get; set; }
        public KingCheckStrategy()
        {
            validateMethod = new ValidateMethod();
            IsFirstMove = true;
        }
        public KingCheckStrategy(bool isFirstMove)
        {
            validateMethod = new ValidateMethod();
            IsFirstMove = isFirstMove;
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

            if (IsFirstMove)
            {
                var castling = new Castling();
                possibleMovies.AddRange(castling.CheckMovies(position, chessboard));
            }

            return possibleMovies;
        }

    }
}
