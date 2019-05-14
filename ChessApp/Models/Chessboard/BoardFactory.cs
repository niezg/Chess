using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Chessboard
{
    public class BoardFactory: IBoardFactory
    {
        public IBoard Create(TypeOfGame kind)
        {
            IPieceFactory pieceFactory = new ChessPieceFactory();

            switch (kind)
            {
                case TypeOfGame.Chess:

                    IBoard chessboard = new ChessboardModel(new ChessMovie());
                    
                    //a1 - h1
                    chessboard.Fields[0, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
                    chessboard.Fields[1, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Knight);
                    chessboard.Fields[2, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Bishop);
                    chessboard.Fields[3, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Queen);
                    chessboard.Fields[4, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.King);
                    chessboard.Fields[5, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Bishop);
                    chessboard.Fields[6, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Knight);
                    chessboard.Fields[7, 0].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Rook);
                    //a2 - h2
                    for (int i = 0; i < 8; i++)
                    {
                        chessboard.Fields[i, 1].Piece = pieceFactory.Create(ColourOfPiece.White, KindOfPiece.Pawn);
                    }
                    //a7 - h7
                    for (int i = 0; i < 8; i++)
                    {
                        chessboard.Fields[i, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Pawn);
                    }
                    //a8 - h8
                    chessboard.Fields[0, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Rook);
                    chessboard.Fields[1, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Knight);
                    chessboard.Fields[2, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Bishop);
                    chessboard.Fields[3, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Queen);
                    chessboard.Fields[4, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.King);
                    chessboard.Fields[5, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Bishop);
                    chessboard.Fields[6, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Knight);
                    chessboard.Fields[7, 6].Piece = pieceFactory.Create(ColourOfPiece.Black, KindOfPiece.Rook);

                    return chessboard;

                case TypeOfGame.Checkers:
                    return null;
                    
                default:
                    return null;
            }
        }
    }
}
