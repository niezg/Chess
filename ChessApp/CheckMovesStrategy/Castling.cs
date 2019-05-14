using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.CheckMovesStrategy
{
    class Castling : ICheckStrategy
    {
        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            var possibleMovies = new List<string>();
            if (AreLeftFieldsEmpty(position, chessboard))
                if (AreRightFieldsEmpty(position, chessboard))
                    if (AreRightFieldsNotAttacking(position, chessboard))
                        if (AreRightFieldsNotAttacking(position, chessboard))
                            return possibleMovies;

                            return possibleMovies;
        }

        private bool AreRightFieldsNotAttacking(Position position, ChessboardModel chessboard)
        {
            var fields = new List<string>();
            var colour = chessboard[position].Piece.Colour;

            for (int i = position.X + 1; i <= 6; i++)
            {
                fields.Add(new Position(i, position.Y).ToString());
            }


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.Fields[i, j].Piece != null &&
                         chessboard.Fields[i, j].Piece.Colour != colour)
                    {
                        chessboard.Fields[i, j].Piece.CheckStrategy.CheckMovies(new Position(i, j), chessboard);
                    }

                }
            }

            return true;
        }

        private bool AreRightFieldsEmpty(Position position, ChessboardModel chessboard)
        {
            for (int i = position.X + 1; i <= 6; i++)
            {
                if (chessboard.GetTypeOfField(new Position(i, position.Y)) != TypeOfField.Empty)
                    return false;
            }

            return true;
        }

        private bool AreLeftFieldsEmpty(Position position, ChessboardModel chessboard)
        {
            for (int i = position.X - 1; i >= 1; i--)
            {
                if (chessboard.GetTypeOfField(new Position(i, position.Y)) != TypeOfField.Empty)
                    return false;
            }

            return true;
        }
    }
}

