using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Chessboard
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        private static readonly char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        

        public Position(string chessPosition)
        {
            chessPosition = chessPosition.Trim().ToLower();
            X = Array.IndexOf(letters, chessPosition[0]);
            Y = int.Parse(chessPosition[1].ToString()) - 1;
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position a, Position b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Position a, Position b)
        {
            return a.X != b.X && a.Y != b.Y;
        }

        public override string ToString()
        {
            string chessXPosition = letters[X].ToString();
            string chessYPosition = (Y+1).ToString();
            string chessPosition = chessXPosition + chessYPosition;

            return  chessPosition;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
