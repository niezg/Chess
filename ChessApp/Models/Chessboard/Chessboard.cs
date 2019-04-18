using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Pieces;

namespace ChessApp
{
    public class Chessboard
    {
        public Dictionary<string, IPiece> Pieces { get; set; }

        internal void MoveTo(string firstPosition, string position)
        {
            throw new NotImplementedException();
        }

        //SelectField();

    }
}
