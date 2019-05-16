using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.CheckMovesStrategy;

namespace ChessApp.Tests.CheckStrategyTests
{
    class CastligTests
    {
        [Test]
        public void CheckMovies_Short_Castling_Oposit_Attack()
        {
            //Arrange
            var chessboard = new ChessboardModel(new ChessMovie());
            var pieceFactory = new ChessPieceFactory();
            chessboard["e1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.King);
            chessboard["h1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
            chessboard["a6"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Bishop);
            chessboard["a6"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Bishop);
            chessboard["h6"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Bishop);
            chessboard["a1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
            var castling = new Castling();
            //Act

            var receivedMovies = castling.CheckMovies(new Position("e1"), chessboard);

            //Assert
            Assert.AreEqual(receivedMovies.Count(), 0);
        }

        [Test]
        public void CheckMovies_Short_Castling_Occupied_Field()
        {
            //Arrange
            var chessboard = new ChessboardModel(new ChessMovie());
            var pieceFactory = new ChessPieceFactory();
            chessboard["e1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.King);
            chessboard["h1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
            chessboard["a6"].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Bishop);
            var castling = new Castling();
            //Act

            var receivedMovies = castling.CheckMovies(new Position("e1"), chessboard);

            //Assert
            Assert.AreEqual(receivedMovies.Count(), 0);
        }

        [Test]
        public void CheckMovies_Short_Castling_Movie_Possible()
        {
            //Arrange
            var chessboard = new ChessboardModel(new ChessMovie());
            var pieceFactory = new ChessPieceFactory();
            chessboard["e1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.King);
            chessboard["h1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
            chessboard["a6"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Bishop);
            var castling = new Castling();
            //Act

            var receivedMovies = castling.CheckMovies(new Position("e1"), chessboard);
            var expectedMovies = new List<string>() { "g1" };
            var commonMovies = receivedMovies.Intersect(expectedMovies);

            //Assert
            Assert.AreEqual(expectedMovies.Count(), commonMovies.Count());
        }

        [Test]
        public void CheckMovies_Both_Castling_Movie_Possible()
        {
            //Arrange
            var chessboard = new ChessboardModel(new ChessMovie());
            var pieceFactory = new ChessPieceFactory();
            chessboard["e1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.King);
            chessboard["h1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
            chessboard["a1"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
            chessboard["a6"].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Bishop);
            var castling = new Castling();
            //Act

            var receivedMovies = castling.CheckMovies(new Position("e1"), chessboard);
            var expectedMovies = new List<string>() { "g1", "c1"};
            var commonMovies = receivedMovies.Intersect(expectedMovies);

            //Assert
            Assert.AreEqual(expectedMovies.Count(), commonMovies.Count());
        }
    }
}
