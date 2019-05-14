using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public class CheckStrategyFactory : ICheckStrategyFactory
    {
        public ICheckStrategy Create(KindOfPiece kindsOfPiece)
        {
            switch (kindsOfPiece)
            {
                case KindOfPiece.Knight:
                    return new KnightCheckStrategy();
                case KindOfPiece.Queen:
                    return new QueenCheckStrategy();
                case KindOfPiece.Rook:
                    return new RookCheckStrategy();
                case KindOfPiece.Pawn:
                    return new PawnCheckStrategy();
                case KindOfPiece.King:
                    return new KingCheckStrategy();
                case KindOfPiece.Bishop:
                    return new BishopCheckStrategy();
            }

            return null;
        }
    }
}