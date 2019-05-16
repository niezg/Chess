using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public class ChessPieceFactory : IPieceFactory
    {
        public IPiece Create(ColourOfPiece colour, KindOfPiece kind, bool isFirstMovie = true)
        {
            ICheckStrategyFactory checkStrategyFactory = new CheckStrategyFactory();
            ICheckStrategy checkStrategy = checkStrategyFactory.Create(kind, isFirstMovie);
            return new ChessPiece(colour, kind, checkStrategy);
        }
    }
}