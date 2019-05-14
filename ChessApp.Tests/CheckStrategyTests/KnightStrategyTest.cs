using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ChessApp.Tests.CheckStrategyTests
{
    public class KnightStrategyTests
    {
        [Test]
        public void CheckMovies_Start_Positions_Test()
        {
            //Arrange
            var boardFactory = new BoardFactory();
            var chessboard = (ChessboardModel)boardFactory.Create(TypeOfGame.Chess);

            //Act
            var possibleMovies = chessboard["b1"].Piece.CheckStrategy.CheckMovies(new Position("b1"), chessboard);
            var actual = possibleMovies.Count();

            //Assert
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void CheckMovies_Few_Possible_Movies_Test()
        {
            //Arrange
            var chessboard = new ChessboardModel(new ChessMovie());
            var pieceFactory = new ChessPieceFactory();
            chessboard["b3"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Knight);
            chessboard["a4"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["d5"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["d1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Pawn);
            chessboard["b5"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["b1"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            chessboard["a5"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Pawn);
            chessboard["c5"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
            
            //Act
            var receivedMovies = chessboard["b3"].Piece.CheckStrategy.CheckMovies(new Position("b3"), chessboard);
            var expectedMovies = new List<string>() { "c5", "d4", "d2", "c1", "a1"};
            var commonMovies = receivedMovies.Intersect(expectedMovies);

            //Assert
            Assert.AreEqual(expectedMovies.Count(), commonMovies.Count());
        }
    
    }
}
