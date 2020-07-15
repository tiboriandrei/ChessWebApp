using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Pieces
{
    public class Horseman : ChessPiece
    {
        public Horseman(bool whiteOrNot) : base(whiteOrNot)
        {
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override bool TryMove(int destColumn, int destRow, string player)
        {
            throw new NotImplementedException();
        }
    }
}
