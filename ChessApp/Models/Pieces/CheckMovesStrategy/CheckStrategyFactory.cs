using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public class CheckStrategyFactory : ICheckStrategyFactory
    {
        public ICheckStrategy Create(KindsOfPiece kindsOfPiece)
        {
            switch (kindsOfPiece)
            {
                case KindsOfPiece.Knight:
                    return new KnightCheckStrategy();
                case KindsOfPiece.Queen:
                    return new QueenCheckStrategy();
                case KindsOfPiece.Rook:
                    return new RookCheckStrategy();
                case KindsOfPiece.Pawn:
                    return new PawnCheckStrategy();
                case KindsOfPiece.King:
                    return new KingCheckStrategy();
                case KindsOfPiece.Bishop:
                    return new BishopCheckStrategy();
            }
            return null;
        }
    }
}