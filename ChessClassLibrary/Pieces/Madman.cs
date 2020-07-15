using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Pieces
{
    public class Madman : ChessPiece
    {
        public Madman(bool whiteOrNot) : base(whiteOrNot)
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
