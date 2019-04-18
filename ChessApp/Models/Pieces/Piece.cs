using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    class Piece : IPiece
    {
        public ColoursOfPiece PieceColour { get; set; }
        public KindsOfPiece Kind { get; set; }
        public bool IsChecked { get; set; }
        public ICheckStrategy CheckStrategy { get; set; }

        public Piece(ColoursOfPiece colour, KindsOfPiece kind, ICheckStrategy checkStrategy)
        {
            PieceColour = colour;
            Kind = kind;
            CheckStrategy = checkStrategy;
        }

       
    }
}
