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

        public override bool TryMove(Table table, Spot origin, Spot dest, string player)
        {
            if (table.Spots[dest.CoordX, dest.CoordY].Occupied == true)
            {
                if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == table.Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
                {
                    //if rook try castle
                    return false;
                }                
            }

            if ( (dest.CoordX == origin.CoordX - 1 || dest.CoordX == origin.CoordX - 1) || (dest.CoordY == origin.CoordY - 1 || dest.CoordY == origin.CoordY + 1))
            {
                //IF DEST = INCHECK, return false;
                return true;
            }
            

            return false;
        }

        public override string ToString()
        {
            return this.PieceColour.ToString() + "King";
        }
    }
}
