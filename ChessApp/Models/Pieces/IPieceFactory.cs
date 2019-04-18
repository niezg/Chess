namespace ChessApp.Models.Pieces
{
    internal interface IPieceFactory
    {
        IPiece Create(ColoursOfPiece colour, KindsOfPiece kind);
    }
}