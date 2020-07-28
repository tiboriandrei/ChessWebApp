using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(bool whiteOrNot) : base(whiteOrNot)
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

            if (dest.CoordY == origin.CoordY)
            {
                if (dest.CoordX < origin.CoordX)
                {
                    for (int i = origin.CoordX-1; i > dest.CoordX; i--)
                    {
                        if (table.Spots[i, dest.CoordY].Occupied)
                        {
                            return false;
                        }
                    }

                    return true;                    
                }

                else if (dest.CoordX > origin.CoordX)
                {
                    for (int i = origin.CoordX+1; i < dest.CoordX; i++)
                    {
                        if (table.Spots[i, dest.CoordY].Occupied)
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            if (dest.CoordX == origin.CoordX)
            {
                if (dest.CoordY < origin.CoordY)
                {
                    for (int i = origin.CoordY-1; i > dest.CoordY; i--)
                    {
                        if (table.Spots[dest.CoordX , i].Occupied)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                else if (dest.CoordY > origin.CoordY)
                {
                    for (int i = origin.CoordY+1; i < dest.CoordY; i++)
                    {
                        if (table.Spots[dest.CoordX, i].Occupied)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.PieceColour.ToString() + "Rook";
        }
    }
}
