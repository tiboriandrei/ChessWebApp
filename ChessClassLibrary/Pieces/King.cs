using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Pieces
{
    public class King : ChessPiece
    {
        public King(bool whiteOrNot) : base(whiteOrNot)
        {
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override bool TryMove(ChessTable table, Spot origin, Spot dest)
        {
            throw new NotImplementedException();
        }
    }
}
