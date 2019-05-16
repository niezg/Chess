using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;

namespace ChessApp.CheckMovesStrategy
{
    public class Castling : ICheckStrategy
    {
        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            var possibleMovies = new List<string>();

            if (IsCastlingPossible(position, chessboard, TypeOfCastling.Long))
                possibleMovies.Add(new Position(2, position.Y).ToString());
            if (IsCastlingPossible(position, chessboard, TypeOfCastling.Short))
                possibleMovies.Add(new Position(6, position.Y).ToString());

            return possibleMovies;
        }

        private bool IsCastlingPossible(Position position, ChessboardModel chessboard, TypeOfCastling typeOfCastling)
        {
            int rookXPosition = 0;

            if (typeOfCastling == TypeOfCastling.Short)
                rookXPosition = 7;

            var rook = chessboard[rookXPosition, position.Y].Piece;
            if (rook == null || rook.Kind != KindOfPiece.Rook)
                return false;

            return (IsRookFirstMove(checkStrategy: rook.CheckStrategy)
                    && AreCastlingFieldsEmpty(typeOfCastling, position, chessboard)
                    && AreCastlingFieldsNotAttacking(typeOfCastling, position, chessboard));
        }
        private bool IsRookFirstMove(ICheckStrategy checkStrategy)
        {
            if (!(checkStrategy is IDifferentFirstMove firstMove))
                throw new FormatException();

            return firstMove.IsFirstMove;
        }
        private bool AreCastlingFieldsNotAttacking(TypeOfCastling typeOfCastling, Position position, ChessboardModel chessboard)
        {
            var colour = chessboard[position].Piece.Colour;

            List<string> checkedFields = GetCastlingFields(typeOfCastling, position.Y);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var attackMovies = new List<string>();

                    if (chessboard.Fields[i, j].Piece != null &&
                         chessboard.Fields[i, j].Piece.Colour != colour)
                    {
                        attackMovies.AddRange(chessboard[i, j].Piece.CheckStrategy.CheckMovies(new Position(i, j), chessboard));
                    }

                    if (!attackMovies.TrueForAll(a => !checkedFields.Contains(a)))
                        return false;
                }
            }

            return true;
        }

        private List<string> GetCastlingFields(TypeOfCastling typeOfCastling, int positionY)
        {
            int firstXPosition = 0, lastXPosition = 0;
            if (typeOfCastling == TypeOfCastling.Short)
            {
                firstXPosition = 4;
                lastXPosition = 6;
            }
            else if (typeOfCastling == TypeOfCastling.Long)
            {
                firstXPosition = 2;
                lastXPosition = 4;
            }

            var fields = new List<string>();
            for (int i = firstXPosition; i <= lastXPosition; i++)
            {
                fields.Add(new Position(i, positionY).ToString());
            }

            return fields;
        }

        private bool AreCastlingFieldsEmpty(TypeOfCastling typeOfCastling, Position position, ChessboardModel chessboard)
        {
            int firstXPosition = 0, lastXPosition = 0;
            if (typeOfCastling == TypeOfCastling.Short)
            {
                firstXPosition = 5;
                lastXPosition = 6;
            }
            else if (typeOfCastling == TypeOfCastling.Long)
            {
                firstXPosition = 2;
                lastXPosition = 3;
            }

            for (int i = firstXPosition; i <= lastXPosition; i++)
            {
                if (chessboard.GetTypeOfField(new Position(i, position.Y)) != TypeOfField.Empty)
                    return false;
            }

            return true;
        }
    }
    enum TypeOfCastling
    {
        Long,
        Short
    }
}

