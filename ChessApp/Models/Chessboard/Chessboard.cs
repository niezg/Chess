using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApp.Models.Pieces;

namespace ChessApp.Models.Chessboard
{
    public class ChessboardModel : IBoard
    {
        public Field[,] Fields { get; set; }
        public IMove MoveStrategy { get; }
        public ChessboardModel(IMove moveStrategy)
        {
            Fields = new Field[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Fields[i, j] = new Field();
                }
            }
            MoveStrategy = moveStrategy;
        }

        

        public TypeOfField GetTypeOfField(Position position)
        {

            if(position.X > 7 || position.X < 0 || position.Y > 7 || position.Y < 0)
            {
                return TypeOfField.OutOfRange;
            }
            else if(Fields[position.X, position.Y].Piece == null)
            {
                return TypeOfField.Empty;
            }
            else if(Fields[position.X, position.Y].Piece.Colour == ColourOfPiece.White)
            {
                return TypeOfField.WhitePiece;
            }
            else if(Fields[position.X, position.Y].Piece.Colour == ColourOfPiece.Black)
            {
                return TypeOfField.BlackPiece;
            }
            else
            {
                throw new ApplicationException("unexpected situation");
            }
            
        }

        public Field this[Position position]
        {
            get
            {
                Field temp = Fields[position.X, position.Y];
                return temp;
            }

            set
            {
                Fields[position.X, position.Y] = value;
            }
        }

        public Field this[string stringPosition]
        {
            get
            {
                Position position = new Position(stringPosition);
                Field temp = Fields[position.X, position.Y];
                return temp;
            }

            set
            {
                Position position = new Position(stringPosition);
                Fields[position.X, position.Y] = value;
            }
        }

        public Field this[int x, int y]
        {
            get
            {
                Field temp = Fields[x, y];
                return temp;
            }

            set
            {
                Fields[x, y] = value;
            }
        }

    }
}
