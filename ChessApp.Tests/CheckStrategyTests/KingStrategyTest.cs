using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ChessApp.Tests.CheckStrategyTests
{
    public class KingStrategyTests
    {
        [Test]
        public void CheckMovies_Start_Positions_Test()
        {
            //Arrange
            var boardFactory = new BoardFactory();
            var chessboard = (ChessboardModel)boardFactory.Create(TypeOfGame.Chess);

            //Act
            var possibleMovies = chessboard["e1"].Piece.CheckStrategy.CheckMovies(new Position("e1"), chessboard);
            var actual = possibleMovies.Count();

            //Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CheckMovies_Few_Possible_Movies_Test()
        {
            //Arrange
            var chessboard = new ChessboardModel(new ChessMovie());
            var pieceFactory = new ChessPieceFactory();
            chessboard["b3"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.King);
            chessboard["a4"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["d5"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["d1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Pawn);
            chessboard["b5"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["b1"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["e3"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Pawn);
            //Act
            var receivedMovies = chessboard["b3"].Piece.CheckStrategy.CheckMovies(new Position("b3"), chessboard);
            var expectedMovies = new List<string>() { "a3", "a2", "a4", "b2", "b4", "c2", "c3", "c4"};
            var commonMovies = receivedMovies.Intersect(expectedMovies);

            //Assert
            Assert.AreEqual(expectedMovies.Count(), commonMovies.Count());
        }
    
    }
}
