using ChessApp.Models.Chessboard;
using System;
using System.Collections.Generic;

namespace ChessApp.Models.Pieces
{
    public class PawnCheckStrategy : ICheckStrategy
    {
        public bool IsFirstMove { get; set; }
        public PawnCheckStrategy()
        {
            IsFirstMove = true;
        }
        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            List<string> possibleMovies = new List<string>();
            var pieceColour = chessboard[position].Piece.Colour;

            if(IsFirstMove)
            {
               possibleMovies.AddRange(CheckMove(2, position, chessboard));
            }

            possibleMovies.AddRange(CheckMove(1, position, chessboard));
            possibleMovies.AddRange(CheckAttack(1, -1, position, chessboard, pieceColour));
            possibleMovies.AddRange(CheckAttack(1, 1, position, chessboard, pieceColour));

            return possibleMovies;
        }
        private List<string> CheckMove(int yStep, Position position, ChessboardModel chessboard)
        {
            position.Y += yStep;
            var typeOfField = chessboard.GetTypeOfField(position);
            if (typeOfField == TypeOfField.Empty)
                return new List<string>() { position.ToString() };
            else return new List<string>();
        }
        private List<string> CheckAttack(int yStep, int xStep, Position position, ChessboardModel chessboard, ColourOfPiece pieceColour)
        {
            position.Y += yStep;
            position.X += xStep;
            var typeOfField = chessboard.GetTypeOfField(position);
            if (typeOfField == TypeOfField.BlackPiece && pieceColour == ColourOfPiece.White ||
                typeOfField == TypeOfField.WhitePiece && pieceColour == ColourOfPiece.Black)
                return new List<string>() { position.ToString() };
            else return new List<string>();
        }
    }
}