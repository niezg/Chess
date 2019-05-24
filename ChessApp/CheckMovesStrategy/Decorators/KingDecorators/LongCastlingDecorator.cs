using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;

namespace ChessApp.CheckMovesStrategy.KingDecorators
{
    public class LongCastlingDecorator : CastlingValidations, IDecorator
    {
        public ICheckStrategy Component { get; set; }
        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            var possibleMovies = new List<string>();

            possibleMovies.AddRange(Component.CheckMovies(position, chessboard));

            if (IsCastlingPossible(TypeOfCastling.Long, position, chessboard))
                possibleMovies.Add(new Position(2, position.Y).ToString());

            return possibleMovies;
        }
    }
}

