using ChessApp.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Chessboard
{
    public class Field
    {
        
        private IPiece piece;

        public IPiece Piece { get => piece; set => piece = value; }

        
    }
}
