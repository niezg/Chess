using ChessApp.Models.Chessboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessApp.Models.Pieces
{
    public interface ICheckStrategy
    {
        List<string> CheckMovies(Position position, Chessboard.ChessboardModel chessboard);
    }
}
