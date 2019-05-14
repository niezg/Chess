
using ChessApp.Models.Chessboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public interface IPiece
    {
        ColourOfPiece Colour { get; set; }

        KindOfPiece Kind { get; set; }

        ICheckStrategy CheckStrategy { get; set; }

    }
}
