using ChessApp.Common;
using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;

namespace ChessApp.CheckMovesStrategy.KingDecorators
{
    public abstract class CastlingValidations
    {

        protected bool IsCastlingPossible(TypeOfCastling typeOfCastling, Position position, ChessboardModel chessboard)
        {
            int rookXPosition;
            int[] emptyFieldXPositions, attackFieldXPositions;
            switch (typeOfCastling)
            {
                case TypeOfCastling.Long:
                    rookXPosition = 0;
                    emptyFieldXPositions = new int[] { 1, 2, 3 };
                    attackFieldXPositions = new int[] { 2, 3, 4 };
                    break;
                case TypeOfCastling.Short:
                    rookXPosition = 7;
                    emptyFieldXPositions = new int[] { 5, 6 };
                    attackFieldXPositions = new int[] {4, 5, 6 };
                    break;
                default:
                    throw new ApplicationException("unexpected argument");
            }
           
            return (IsRookExist(rookXPosition, rookYPosition: position.Y, chessboard)
                   && AreCastlingFieldsEmpty(emptyFieldXPositions, position, chessboard)
                   && AreCastlingFieldsNotAttacking(attackFieldXPositions, position, chessboard));
        }
        private bool AreCastlingFieldsNotAttacking(int[] attackFieldXPositions, Position position, ChessboardModel chessboard)
        {
            var colour = chessboard[position].Piece.Colour;

            List<string> checkedFields = GetCastlingAttackFields(attackFieldXPositions, position.Y);

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
        private List<string> GetCastlingAttackFields(int[] attackFieldXPositions, int positionY)
        {
            var fields = new List<string>();

            foreach (var positionX in attackFieldXPositions)
            {
                fields.Add(new Position(positionX, positionY).ToString());
            }

            return fields;
        }

        private bool AreCastlingFieldsEmpty(int[] emptyFieldXPositions, Position position, ChessboardModel chessboard)
        {
            foreach (var positionX in emptyFieldXPositions)
            {
                if (chessboard.GetTypeOfField(new Position(positionX, position.Y)) != TypeOfField.Empty)
                    return false;
            }

            return true;
        }

        private bool IsRookExist(int rookXPosition, int rookYPosition, ChessboardModel chessboard)
        {
            var rook = chessboard[rookXPosition, rookYPosition].Piece;
            return (rook != null && rook.Kind == KindOfPiece.Rook);
        }
    }
}
