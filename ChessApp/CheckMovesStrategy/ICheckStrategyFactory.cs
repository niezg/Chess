namespace ChessApp.Models.Pieces
{
    public interface ICheckStrategyFactory
    {
        ICheckStrategy Create(KindOfPiece kindsOfPiece);
    }
}