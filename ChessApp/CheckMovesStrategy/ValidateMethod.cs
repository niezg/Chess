using ChessApp.Models.Chessboard;
using System;
using System.Collections.Generic;

namespace ChessApp.Models.Pieces
{
    public class ValidateMethod
    {
        public List<string> CheckQuarter(int xStep, int yStep, Position position, ChessboardModel chessboard, bool addNextStep = true)
        {
            var possibleMovies = new List<string>();
            bool doNextIteration = false;
            var colour = chessboard[position].Piece.Colour;

            do
            {
                position.X += xStep;
                position.Y += yStep;
                TypeOfField typeOfField = chessboard.GetTypeOfField(position);

                if(addNextStep)
                doNextIteration = DoNextIteration(typeOfField);

                if (IsMovePossible(typeOfField, colour))
                    possibleMovies.Add(position.ToString());
            }
            while (doNextIteration);

            return possibleMovies;
        }

        private bool IsMovePossible(TypeOfField typeOfField, ColourOfPiece colour)
        {
            switch (typeOfField)
            {
                case TypeOfField.Empty:
                    return true;
                case TypeOfField.OutOfRange:
                    return false;
                case TypeOfField.WhitePiece:
                    return !IsColorTheSame(typeOfField, colour);
                case TypeOfField.BlackPiece:
                    return !IsColorTheSame(typeOfField, colour);
                default:
                    throw new ApplicationException("nieznany typ");
            }
        }

        private bool IsColorTheSame(TypeOfField typeOfField, ColourOfPiece colour)
        {
            return (typeOfField == TypeOfField.BlackPiece && colour == ColourOfPiece.Black
                    || typeOfField == TypeOfField.WhitePiece && colour == ColourOfPiece.White);
        }

        private bool DoNextIteration(TypeOfField typeOfField)
        {
            switch (typeOfField)
            {
                case TypeOfField.Empty:
                    return true;
                case TypeOfField.OutOfRange:
                    return false;
                case TypeOfField.WhitePiece:
                    return false;
                case TypeOfField.BlackPiece:
                    return false;
                default:
                    throw new ApplicationException("nieznany typ");
            }
        }
    }
}
