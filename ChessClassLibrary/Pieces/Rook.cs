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

        public override Table MarkAttackedSpots(Table table, Spot origin, string player)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (origin.CoordX + i <= 7)
                {
                    if (player == "White")
                    {
                        table.Spots[origin.CoordX + i, origin.CoordY].NotSafeForBK = true;
                    }
                    else if (player == "Black") {
                        table.Spots[origin.CoordX + i, origin.CoordY].NotSafeForWK = true;
                    }

                    if (table.Spots[origin.CoordX + i, origin.CoordY].Occupied)
                    {
                        break;
                    }                    
                }
                else { break; }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (origin.CoordX - i >= 0)
                {
                    if (player == "White")
                    {
                        table.Spots[origin.CoordX - i, origin.CoordY].NotSafeForBK = true;
                    }
                    else if (player == "Black")
                    {
                        table.Spots[origin.CoordX - i, origin.CoordY].NotSafeForWK = true;
                    }

                    if (table.Spots[origin.CoordX - i, origin.CoordY].Occupied)
                    {
                        break;
                    }
                }
                else { break; }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (origin.CoordY - i >= 0)
                {
                    if (player == "White")
                    {
                        table.Spots[origin.CoordX, origin.CoordY - i].NotSafeForBK = true;
                    }
                    else if (player == "Black")
                    {
                        table.Spots[origin.CoordX, origin.CoordY - i].NotSafeForWK = true;
                    }

                    if (table.Spots[origin.CoordX, origin.CoordY - i].Occupied)
                    {
                        break;
                    }
                }
                else { break; }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (origin.CoordY + i <= 7)
                {
                    if (player == "White")
                    {
                        table.Spots[origin.CoordX, origin.CoordY + i].NotSafeForBK = true;
                    }
                    else if (player == "Black")
                    {
                        table.Spots[origin.CoordX, origin.CoordY + i].NotSafeForWK = true;
                    }

                    if (table.Spots[origin.CoordX, origin.CoordY + i].Occupied)
                    {
                        break;
                    }
                }
                else { break; }
            }

            return table;

        }
    }
}
