using ChessApp.Models.Chessboard;
using ChessApp.Models.Pieces;

namespace ChessApp.Models
{
    class ViewModel
    {
        public ViewField[,] Fields { get; set; }
        public ViewModel()
        {
            Fields = new ViewField[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Fields[i, j] = new ViewField();
                }
            }
        }
        public ViewField this[string stringPosition]
        {
            get
            {
                Position position = new Position(stringPosition);
                ViewField temp = Fields[position.X, position.Y];
                return temp;
            }

            set
            {
                Position position = new Position(stringPosition);
                Fields[position.X, position.Y] = value;
            }
        }
    }

    class ViewField
    {
        ViewPiece Piece { get; set; }

        private ColourOfField FieldColour { get; }

        private string ImagePath;

        public string MyProperty
        {
            get {
                switch (FieldColour)
                {
                    case ColourOfField.Dark:
                        return "";
                    case ColourOfField.Light:
                        return "";
                    default:
                        return "";
                }
            }
        }

        enum ColourOfField
    {
        Dark,
        Light
    }

    internal class ViewPiece
    {
        public ColourOfPiece PieceColour { get; set; }
        public KindOfPiece PieceKind { get; set; }

            private string imgePath;

            public string ImagePath
            {
                get
                {
                    return "Images/ChessPieces/" + PieceColour + PieceKind;
                }
            }
        }
    }
}