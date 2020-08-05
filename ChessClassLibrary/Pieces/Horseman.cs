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

        public override bool TryMove(Spot[,] Spots, Spot origin, Spot dest, string player)
        {
            if (Spots[dest.CoordX, dest.CoordY].Occupied == true)
            {
                if (Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
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
                return true;                                                                                                          
            }

            return false;
        }

        public override Spot[,] MarkAttackedSpots(Spot[,] Spots, Spot origin, string player)
        {
            if (origin.CoordX - 1 >=0 && origin.CoordY - 2 >= 0)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX - 1, origin.CoordY - 2].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX - 1, origin.CoordY - 2].NotSafeForWK = true;
                }
            }

            if (origin.CoordX - 1 >= 0 && origin.CoordY + 2 <= 7)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX - 1, origin.CoordY + 2].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX - 1, origin.CoordY + 2].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 1 <= 7 && origin.CoordY - 2 >= 0)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX + 1, origin.CoordY - 2].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX + 1, origin.CoordY - 2].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 1 <= 7 && origin.CoordY + 2 <= 7)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX + 1, origin.CoordY + 2].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX + 1, origin.CoordY + 2].NotSafeForWK = true;
                }
            }

            ///

            if (origin.CoordX - 2 >= 0 && origin.CoordY - 1 >= 0)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX - 2, origin.CoordY - 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX - 2, origin.CoordY - 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX - 2 >= 0 && origin.CoordY + 1 <= 7)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX - 2, origin.CoordY + 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX - 2, origin.CoordY + 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 2 <= 7 && origin.CoordY - 1 >= 0)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX + 2, origin.CoordY - 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX + 2, origin.CoordY - 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 2 <= 7 && origin.CoordY + 1 <= 7)
            {
                if (player == "White")
                {
                    Spots[origin.CoordX + 2, origin.CoordY + 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    Spots[origin.CoordX + 2, origin.CoordY + 1].NotSafeForWK = true;
                }
            }


            return Spots;

        }
    }
}
