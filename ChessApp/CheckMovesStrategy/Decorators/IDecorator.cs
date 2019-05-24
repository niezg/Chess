using ChessApp.Models.Pieces;
using System.ComponentModel;

namespace ChessApp.CheckMovesStrategy.KingDecorators
{
    public interface IDecorator : ICheckStrategy
    {
        ICheckStrategy Component { get; set; }
    }
}
