using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    class PieceFactory : IPieceFactory
    {
        public IPiece Create(ColoursOfPiece colour, KindsOfPiece kind)
        {
            ICheckStrategyFactory checkStrategyFactory = new CheckStrategyFactory();
            ICheckStrategy checkStrategy = checkStrategyFactory.Create(kind);

            IPiece piece = new Piece(colour, kind, checkStrategy);
            
        }
    }
}