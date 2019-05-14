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
            else if (firstField.Piece.Colour == secondField.Piece.Colour)
            {
                Castling(firstField, secondField);
            }
            else
            {
                Attack(firstField, secondField);
            }
        }

        private void Attack(Field firstField, Field secondField)
        {
            secondField.Piece = firstField.Piece;
            firstField.Piece = null;
        }

        private void Castling(Field firstField, Field secondField)
        {
            var bufor = firstField.Piece;
            firstField.Piece = secondField.Piece;
            secondField.Piece = bufor;
        }

        private void NormalMove(Field firstField, Field secondField)
        {
            secondField.Piece = firstField.Piece;
            firstField.Piece = null;
        }
    }
}
