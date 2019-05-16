using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public class CheckStrategyFactory : ICheckStrategyFactory
    {
        public ICheckStrategy Create(KindOfPiece kindsOfPiece, bool isFirstMovie)
        {
            switch (kindsOfPiece)
            {
                case KindOfPiece.Knight:
                    return new KnightCheckStrategy();
                case KindOfPiece.Queen:
                    return new QueenCheckStrategy();
                case KindOfPiece.Rook:
                    return new RookCheckStrategy(isFirstMovie);
                case KindOfPiece.Pawn:
                    return new PawnCheckStrategy();
                case KindOfPiece.King:
                    return new KingCheckStrategy(isFirstMovie);
                case KindOfPiece.Bishop:
                    return new BishopCheckStrategy();
            }

            return null;
        }
    }
}