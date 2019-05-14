namespace ChessApp.Models.Pieces
{
    internal interface IPieceFactory
    {
        IPiece Create(ColourOfPiece colour, KindOfPiece kind);
    }
}