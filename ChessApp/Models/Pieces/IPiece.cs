
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public interface IPiece
    {
        ColoursOfPiece PieceColor { get; set; }

        KindsOfPiece Kind { get; set; }

        bool IsChecked { get; set; }



        //protected readonly List<string> possibleMoves;

        //abstract public void Move();
    }
}
