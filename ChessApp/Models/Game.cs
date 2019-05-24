using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;


namespace ChessApp
{
    class Game
    {
        private ChessboardModel Chessboard { get; set; }
        private ColourOfPiece PlayerColour { get; set; }
        private Position? FirstPosition { get; set; }

        internal void ClickField(Position position)
        {
            if(FirstPosition == null)
            {
                FirstPosition = position;
                FirstClick(position);
            }
            else if(position == FirstPosition.Value)
            {
                FirstPosition = null;
            }
            else
            {
                SecondClick(position);
            }
        }
        private void FirstClick(Position position)
        {
            var selectedPiece = Chessboard[position].Piece;

            if (IsPlayerPiece(selectedPiece))
            {
                {
                    selectedPiece.CheckStrategy.CheckMovies(position, Chessboard);
                }
            }
        }

        private bool IsPlayerPiece(IPiece selectedPiece) => selectedPiece.Colour == PlayerColour;

        private void SecondClick(Position position)
        {
            var playerPiece = Chessboard[FirstPosition.Value].Piece;

            if (playerPiece.CheckStrategy.CheckMovies(FirstPosition.Value, Chessboard).Contains(position.ToString()))
            {
                Chessboard.MoveStrategy.Move(FirstPosition.Value, position, Chessboard);
                
                ChangePlayer();

               //DisplayChanges();
            }
        }

        private void ChangePlayer()
        {
            FirstPosition = null;

            if (PlayerColour == ColourOfPiece.Black)
                PlayerColour = ColourOfPiece.White;
            else
                PlayerColour = ColourOfPiece.Black;
        }

        public Game(TypeOfGame kindOfGame)
        {
            IBoardFactory boardFactory = new BoardFactory();
            Chessboard = (ChessboardModel) boardFactory.Create(kindOfGame);
            PlayerColour = ColourOfPiece.White;
        }
    }
}
