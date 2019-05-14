using ChessApp.Models.Chessboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    class AdvancePiece: ChessPiece, IDifferentFirstMove
    {
        
        public bool IsFirstMove { get; set; }

        public AdvancePiece(ColourOfPiece colour, KindOfPiece kind, ICheckStrategy checkStrategy)
            :base(colour, kind, checkStrategy)
        {
            IsFirstMove = true;
        }

    }
}
