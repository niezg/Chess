using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;

namespace ChessApp.CheckMovesStrategy.KingDecorators
{
    class FirstMovieDecorator : IDecorator, IFirstMove
    {
        public ICheckStrategy Component { get; set; }

        public List<string> CheckMovies(Position position, ChessboardModel chessboard)
        {
            return Component.CheckMovies(position, chessboard);
        }
    }
}
