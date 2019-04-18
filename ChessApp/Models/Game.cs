using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Pieces;
using ChessApp.Models.Pieces.ActionsStrategy;

namespace ChessApp
{
    class Game
    {
        public Chessboard Chessboard { get; set; }
        private ColoursOfPiece PlayerColour { get; set; }
        private ICheckStrategy CheckStrategy { get; set; }
        private bool IsSomePieceChecked { get; set; }
        private string FirstPosition { get; set; }
        private List<string> PossibleMovies { get; set; }

        internal void ClickField(string position)
        {
            if (Chessboard.Pieces[position].IsChecked)
            {
                Chessboard.Pieces[position].IsChecked = false;
                FirstPosition = "None";
            }
            else if (FirstPosition == "None")
            {
                FirstClick(position);
            }
            else
            {
                SecondClick(position);
            }

            //IPiece piece = new IPiece()
            
        }

        private void SecondClick(string position)
        {
            if (PossibleMovies.Contains(position))
            {
                Chessboard.MoveTo(FirstPosition, position);
                FirstPosition = "None";
            }
        }

        private void FirstClick(string position)
        {
            if (Chessboard.Pieces[position].PieceColor == PlayerColour)
            {
                if (Chessboard.Pieces[position].IsChecked)
                {
                    Chessboard.Pieces[position].IsChecked = false;
                }
                else
                {
                    Chessboard.Pieces[position].IsChecked = true;

                    PossibleMovies = Chessboard.Pieces[position].CheckStrategy.CheckMovies(position);

                    FirstPosition = position;
                
                }
            }
        }

        public Game()
        {
            Chessboard = new Chessboard();
            PlayerColour = ColoursOfPiece.White;
            FirstPosition = "None";
        }
    }
}
