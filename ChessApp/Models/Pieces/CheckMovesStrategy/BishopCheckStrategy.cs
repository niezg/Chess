using ChessApp.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    class BishopCheckStrategy : ICheckStrategy
    {
        public static List<string> Bishop(string position)
        {
            var possibleActions = new List<string>();
            var positionXY = new Position(position);
            int currentX = positionXY.X;
            int currentY = positionXY.Y;

            while (currentX <= 8 && currentY <= 8)
            {

            }


        }
    }
}
