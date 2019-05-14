namespace ChessApp.Models.Chessboard
{
    public interface IMove
    {
        void Move(Position firstPosition, Position secondPosition, ChessboardModel chessboard);
    }
}