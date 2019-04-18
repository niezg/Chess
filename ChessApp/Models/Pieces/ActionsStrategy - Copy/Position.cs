using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Chessboard
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        private readonly char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        public Position( string position)
        {
            X = Array.IndexOf(letters, position[0]) + 1;
            Y = position[1];
        }
    }
}
