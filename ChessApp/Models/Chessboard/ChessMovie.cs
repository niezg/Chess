using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Chessboard
{
    public class ChessMovie: IMove
    {
        public void Move(Position firstPosition, Position secondPosition, ChessboardModel chessboard)
        {
            Field firstField = chessboard[firstPosition];
            Field secondField = chessboard[secondPosition];

            if (secondField.Piece == null)
            {
                NormalMove(firstField, secondField);
            }
            else if (firstField.Piece.Kind == KindOfPiece.King 
                     && firstField.Piece.CheckStrategy is IDifferentFirstMove firstMoveProperty 
                     && firstMoveProperty.IsFirstMove && (secondPosition.X == 2 || secondPosition.X == 6))
            {

                Castling(firstField, secondField, secondPosition, chessboard);
            }
            else if(firstField.Piece.Colour != secondField.Piece.Colour)
            {
                Attack(firstField, secondField);
            }
            else
            {
                throw new ApplicationException("unexpected state");
            }
        }

        private void Attack(Field firstField, Field secondField)
        {
            secondField.Piece = firstField.Piece;
            firstField.Piece = null;
        }

        private void Castling(Field firstField, Field secondField, Position kingPosition, ChessboardModel chessboard)
        {
            secondField.Piece = firstField.Piece;
            firstField.Piece = null;
            var kingCheckStrategy = secondField.Piece.CheckStrategy as KingCheckStrategy;
            kingCheckStrategy.IsFirstMove = false;

            ChangeRookPosition(kingPosition, chessboard);
        }

        private void ChangeRookPosition(Position kingPosition, ChessboardModel chessboard)
        {
            if (kingPosition.X == 2)
            {
                chessboard[3, kingPosition.Y].Piece = chessboard[0, kingPosition.Y].Piece;
                chessboard[0, kingPosition.Y].Piece = null;
                var rookCheckStrategy = chessboard[3, kingPosition.Y].Piece.CheckStrategy as RookCheckStrategy;
                rookCheckStrategy.IsFirstMove = false;
            }
            else if (kingPosition.X == 6)
            {
                chessboard[5, kingPosition.Y].Piece = chessboard[7, kingPosition.Y].Piece;
                chessboard[7, kingPosition.Y].Piece = null;
                var rookCheckStrategy = chessboard[5, kingPosition.Y].Piece.CheckStrategy as RookCheckStrategy;
                rookCheckStrategy.IsFirstMove = false;
            }
            else
            {
                throw new ApplicationException("unexpected staitment");
            }
        }

        private void NormalMove(Field firstField, Field secondField)
        {
            secondField.Piece = firstField.Piece;
            firstField.Piece = null;
        }
    }
}
