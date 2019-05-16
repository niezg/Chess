using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Models.Pieces
{
    public interface IDifferentFirstMove
    {
        bool IsFirstMove { get; set; }
    }
}
