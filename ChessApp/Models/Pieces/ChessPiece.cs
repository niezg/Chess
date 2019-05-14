using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Chessboard;

namespace ChessApp.Models.Pieces
{
    class ChessPiece : IPiece
    {
        public ColourOfPiece Colour { get; set; }
        public KindOfPiece Kind { get; set; }
        public ICheckStrategy CheckStrategy { get; set; }
        
        
        public ChessPiece(ColourOfPiece colour, KindOfPiece kind, ICheckStrategy checkStrategy)
        {
            Colour = colour;
            Kind = kind;
            CheckStrategy = checkStrategy;
        }
    }
}
