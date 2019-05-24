using ChessApp.CheckMovesStrategy.KingDecorators;
using ChessApp.Models.Pieces;
using System;

namespace ChessApp.CheckMovesStrategy
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
                    if (isFirstMovie)
                    {
                        var checkStrategy = new RookCheckStrategy();
                        var firstMoveDecorator = new FirstMovieDecorator();
                        firstMoveDecorator.Component = checkStrategy;
                        return firstMoveDecorator;
                    }
                    else return new RookCheckStrategy();
                case KindOfPiece.Pawn:
                    return new PawnCheckStrategy();
                case KindOfPiece.King:
                    if (isFirstMovie)
                    return CreateKingStrategyWithCastlingDecorator(TypeOfCastling.Both);
                    else return new KingCheckStrategy();
                case KindOfPiece.Bishop:
                    return new BishopCheckStrategy();
                default:
                    throw new ApplicationException("unexpected argument");
            }
        }

            public ICheckStrategy CreateKingStrategyWithCastlingDecorator(TypeOfCastling typeOfCastling)
            {
                var checkStrategy = new KingCheckStrategy();
                var firstMovieDecorator = new FirstMovieDecorator();
                var shortCastlingDecorator = new ShortCastlingDecorator();
                var longCastlingDecorator = new LongCastlingDecorator();
                firstMovieDecorator.Component = checkStrategy;

            switch (typeOfCastling)
            {
                case TypeOfCastling.Long:
                    longCastlingDecorator.Component = firstMovieDecorator;
                    return longCastlingDecorator;
                case TypeOfCastling.Short:
                    shortCastlingDecorator.Component = firstMovieDecorator;
                    return shortCastlingDecorator;
                case TypeOfCastling.Both:
                    longCastlingDecorator.Component = firstMovieDecorator;
                    shortCastlingDecorator.Component = longCastlingDecorator;
                    return shortCastlingDecorator;
                default:
                    throw new ApplicationException("unexpected argument");
            }
        }
    }
}