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
          
        public override bool TryMove(Table table, Spot origin, Spot dest, string player)
        {
            if (table.Spots[dest.CoordX, dest.CoordY].Occupied == true)
            {
                if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == table.Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
                {
                    return false;
                }
            }

            if (dest.CoordX != origin.CoordX && dest.CoordY != origin.CoordY && (Math.Abs(origin.CoordX - dest.CoordX) == Math.Abs(origin.CoordY - dest.CoordY)) )
            {
                for (int i = 1; i < Math.Abs(origin.CoordX - dest.CoordX); i++)
                {
                    if (dest.CoordX < origin.CoordX && dest.CoordY < origin.CoordY)     //sw
                    {
                        if (table.Spots[origin.CoordX-i, origin.CoordY-i].Occupied)
                        {
                            return false;
                        }
                    }

                    if (dest.CoordX > origin.CoordX && dest.CoordY < origin.CoordY)     //se
                    {
                        if (table.Spots[origin.CoordX + i, origin.CoordY - i].Occupied)
                        {
                            return false;
                        }
                    }

                    if (dest.CoordX < origin.CoordX && dest.CoordY > origin.CoordY)     //nw
                    {
                        if (table.Spots[origin.CoordX - i, origin.CoordY + i].Occupied)
                        {
                            return false;
                        }
                    }

                    if (dest.CoordX > origin.CoordX && dest.CoordY > origin.CoordY)     //ne
                    {
                        if (table.Spots[origin.CoordX + i, origin.CoordY + i].Occupied)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.PieceColour.ToString() + "Madman";
        }
    }
}
