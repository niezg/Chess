using ChessApp.CheckMovesStrategy;
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

            IsCastlingDecoratorChange(firstPosition, secondPosition, chessboard);

            if (secondField.Piece == null)
            {
                NormalMove(firstField, secondField);
            }
            else if (firstField.Piece.Kind == KindOfPiece.King 
                     && firstPosition.X == 4
                     && (secondPosition.X == 2 || secondPosition.X == 6))
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

        private void IsCastlingDecoratorChange(Position firstPosition, Position secondPosition, ChessboardModel chessboard)
        {
            Field firstField = chessboard[firstPosition];
            Field secondField = chessboard[secondPosition];

            if (secondField.Piece?.CheckStrategy is IFirstMove)
                CastlingDecoratorChanges(secondField.Piece, secondPosition, chessboard);
            if (firstField.Piece.CheckStrategy is IFirstMove)
                CastlingDecoratorChanges(firstField.Piece, firstPosition, chessboard);
        }

        private void CastlingDecoratorChanges(IPiece piece, Position position, ChessboardModel chessboard)
        {
            var strategyFacctory = new CheckStrategyFactory();

            switch (piece.Kind)
            {
                case KindOfPiece.Knight:
                    piece.CheckStrategy = strategyFacctory.Create(piece.Kind, false);
                    if (chessboard[0, position.Y].Piece?.Kind == KindOfPiece.Rook)
                        chessboard[0, position.Y].Piece.CheckStrategy = strategyFacctory.Create(KindOfPiece.Rook, false);
                    if (chessboard[7, position.Y].Piece?.Kind == KindOfPiece.Rook)
                        chessboard[7, position.Y].Piece.CheckStrategy = strategyFacctory.Create(KindOfPiece.Rook, false);
                    break;
                
                case KindOfPiece.Rook:
                    piece.CheckStrategy = strategyFacctory.Create(piece.Kind, false);
                    if (position.X == 0)
                     chessboard[4, position.Y].Piece.CheckStrategy = strategyFacctory.CreateKingStrategyWithCastlingDecorator(TypeOfCastling.Short);
                    else if(position.X == 7)
                     chessboard[4, position.Y].Piece.CheckStrategy = strategyFacctory.CreateKingStrategyWithCastlingDecorator(TypeOfCastling.Long);
                    break;

                default: throw new ApplicationException("unexpected argument");
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

            ChangeRookPosition(kingPosition, chessboard);
        }

        private void ChangeRookPosition(Position kingPosition, ChessboardModel chessboard)
        {
            if (kingPosition.X == 2)
            {
                chessboard[3, kingPosition.Y].Piece = chessboard[0, kingPosition.Y].Piece;
                chessboard[0, kingPosition.Y].Piece = null;
            }
            else if (kingPosition.X == 6)
            {
                chessboard[5, kingPosition.Y].Piece = chessboard[7, kingPosition.Y].Piece;
                chessboard[7, kingPosition.Y].Piece = null;
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
