using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;

namespace ChessApp.CheckMovesStrategy
{
   public class BadCastling : ICheckStrategy
    {
        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            var possibleMovies = new List<string>();

            switch (position.X)
            {
                case 4:
                    if(IsLeftCastlingPossible(position, chessboard, KindOfPiece.King))
                        possibleMovies.Add(new Position(2, position.Y).ToString());
                    if(IsRightCastlingPossible(position, chessboard, KindOfPiece.King))
                        possibleMovies.Add(new Position(6,position.Y).ToString());
                    break;
                case 0:
                    if (IsLeftCastlingPossible(position, chessboard, KindOfPiece.Rook))
                        possibleMovies.Add(new Position(3, position.Y).ToString());
                    break;
                case 7:
                    if (IsRightCastlingPossible(position, chessboard, KindOfPiece.Rook))
                        possibleMovies.Add(new Position(5, position.Y).ToString());
                    break;
                default: throw new FormatException(position.X.ToString());
            }

            return possibleMovies;
        }

        private bool IsRightCastlingPossible(Position position, ChessboardModel chessboard, KindOfPiece kindOfPiece)
        {
            if (chessboard[position].Piece.Kind != kindOfPiece)
                throw new FormatException(nameof(kindOfPiece));

            switch (kindOfPiece)
            {
                case KindOfPiece.King:
                    if (IsSecondPieceFirstMove(checkStrategy: chessboard[7, position.Y].Piece.CheckStrategy)
                        && AreCastlingFieldsEmpty(SideOfCastling.Right, position, chessboard)
                        && AreCastlingFieldsNotAttacking(SideOfCastling.Right, position, chessboard))
                        return true;
                    break;
                    
                case KindOfPiece.Rook:
                    if (IsSecondPieceFirstMove(checkStrategy: chessboard[4, position.Y].Piece.CheckStrategy)
                        && AreCastlingFieldsEmpty(SideOfCastling.Right, position, chessboard)
                        && AreCastlingFieldsNotAttacking(SideOfCastling.Right, position, chessboard))
                        return true;
                    break;
            }
            return false;
        }

        private bool IsLeftCastlingPossible(Position position, ChessboardModel chessboard, KindOfPiece kindOfPiece)
        {
            if (chessboard[position].Piece.Kind != kindOfPiece)
                throw new FormatException(nameof(kindOfPiece));

            switch (kindOfPiece)
            {
                case KindOfPiece.King:
                    if (IsSecondPieceFirstMove(checkStrategy: chessboard[0, position.Y].Piece.CheckStrategy)
                        && AreCastlingFieldsEmpty(SideOfCastling.Left, position, chessboard)
                        && AreCastlingFieldsNotAttacking(SideOfCastling.Left, position, chessboard))
                        return true;
                    break;

                case KindOfPiece.Rook:
                    if (IsSecondPieceFirstMove(checkStrategy: chessboard[4, position.Y].Piece.CheckStrategy)
                        && AreCastlingFieldsEmpty(SideOfCastling.Left, position, chessboard)
                        && AreCastlingFieldsNotAttacking(SideOfCastling.Left, position, chessboard))
                        return true;
                    break;
            }
            return false;
        }

        private bool IsSecondPieceFirstMove(ICheckStrategy checkStrategy)
        {
            var firstMove = checkStrategy as IDifferentFirstMove;
            if (firstMove == null)
                throw new FormatException();

            return firstMove.IsFirstMove;
        }
        private bool AreCastlingFieldsNotAttacking(SideOfCastling sideOfCastling, Position position, ChessboardModel chessboard)
        {
            var colour = chessboard[position].Piece.Colour;

            List<string> checkedFields = GetCastlingFields(sideOfCastling, position.Y);

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

        private List<string> GetCastlingFields(SideOfCastling sideOfCastling, int positionY)
        {
            int firstXPosition = 0, lastXPosition = 0;
            if (sideOfCastling == SideOfCastling.Right)
            {
                firstXPosition = 5;
                lastXPosition = 6;
            }
            else if (sideOfCastling == SideOfCastling.Left)
            {
                firstXPosition = 1;
                lastXPosition = 3;
            }

            var fields = new List<string>();
            for (int i = firstXPosition; i <= lastXPosition; i++)
            {
                fields.Add(new Position(i, positionY).ToString());
            }

            return fields;
        }

        private bool AreCastlingFieldsEmpty(SideOfCastling sideOfCastling, Position position, ChessboardModel chessboard)
        {
            int firstXPosition = 0, lastXPosition = 0;
            if (sideOfCastling == SideOfCastling.Right)
            {
                firstXPosition = 5;
                lastXPosition = 6;
            }
            else if (sideOfCastling == SideOfCastling.Left)
            {
                firstXPosition = 1;
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
    enum SideOfCastling
    {
        Right,
        Left
    }
}

