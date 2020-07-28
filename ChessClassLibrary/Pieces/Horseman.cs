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

        public override bool TryMove(Table table, Spot origin, Spot dest, string player)
        {
            if (table.Spots[dest.CoordX, dest.CoordY].Occupied == true)
            {
                if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == table.Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
                {
                    return false;
                }
            }

            if (Math.Abs(dest.CoordX - origin.CoordX) == 1 && Math.Abs(dest.CoordY - origin.CoordY) == 2)
            {
                return true;
            }

            if (Math.Abs(dest.CoordX - origin.CoordX) == 2 && Math.Abs(dest.CoordY - origin.CoordY) == 1)
            {
                return true;                                                                                                          //(saved horse implementation for last, i thought it would be most difficult piece to implement lol...)
            }

            return false;
        }

        public override string ToString()
        {
            return this.PieceColour.ToString() + "Horseman";
        }
    }
}
