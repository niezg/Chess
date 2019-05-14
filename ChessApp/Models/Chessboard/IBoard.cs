using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Chessboard
{
    public interface IBoard
    {
        Field[,] Fields { get; set; }
        IMove MoveStrategy { get; }
    }
}
