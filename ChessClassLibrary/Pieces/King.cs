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
                    if (table.Spots[dest.CoordX, dest.CoordY].Piece.ToString() == "WhiteRook" && origin.CoordX == 3 && origin.CoordY == 7
                        && ((dest.CoordX == 0 && dest.CoordY == 7) || (dest.CoordX == 7 && dest.CoordY == 7)))
                    {
                        if (dest.CoordX > origin.CoordX)
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (table.Spots[dest.CoordX + 1, dest.CoordY].Occupied)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }

                        if (dest.CoordX < origin.CoordX)
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                if (table.Spots[dest.CoordX - 1, dest.CoordY].Occupied)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }

                    }
                    return false;
                }                
            }

            if ( ((dest.CoordX == origin.CoordX - 1 && dest.CoordX == origin.CoordY - 1)) || ((dest.CoordY == origin.CoordX - 1 && dest.CoordY == origin.CoordY + 1)) ||
                ((dest.CoordX == origin.CoordY + 1 && dest.CoordX == origin.CoordY - 1)) || ((dest.CoordX == origin.CoordY + 1 && dest.CoordX == origin.CoordY + 1)) ||

                ((dest.CoordX == origin.CoordX - 1 && dest.CoordX == origin.CoordY)) || ((dest.CoordX == origin.CoordX + 1 && dest.CoordX == origin.CoordY)) ||
                ((dest.CoordX == origin.CoordX && dest.CoordX == origin.CoordY - 1)) || ((dest.CoordX == origin.CoordX && dest.CoordX == origin.CoordY + 1)))
            {               
                return true;
            }            

            return false;
        }

        public override Table MarkAttackedSpots(Table table, Spot origin, string player)
        {
            if (origin.CoordX - 1 >= 0 && origin.CoordY - 1 >= 0)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX - 1, origin.CoordY - 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX - 1, origin.CoordY - 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX - 1 >= 0 && origin.CoordY + 1 <= 7)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX - 1, origin.CoordY + 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX - 1, origin.CoordY + 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 1 <= 7 && origin.CoordY - 1 >= 0)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX + 1, origin.CoordY - 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX + 1, origin.CoordY - 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 1 <= 7 && origin.CoordY + 1 <= 7)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX + 1, origin.CoordY + 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX + 1, origin.CoordY + 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordX + 1 <= 7)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX + 1, origin.CoordY].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX + 1, origin.CoordY].NotSafeForWK = true;
                }
            }

            if (origin.CoordX - 1 >= 0)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX - 1, origin.CoordY].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX - 1, origin.CoordY].NotSafeForWK = true;
                }
            }

            if (origin.CoordY + 1 <= 7)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX, origin.CoordY + 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX, origin.CoordY + 1].NotSafeForWK = true;
                }
            }

            if (origin.CoordY - 1 >= 0)
            {
                if (player == "White")
                {
                    table.Spots[origin.CoordX, origin.CoordY - 1].NotSafeForBK = true;
                }
                else if (player == "Black")
                {
                    table.Spots[origin.CoordX, origin.CoordY - 1].NotSafeForWK = true;
                }
            }

            return table;
        }

        public bool IsCheckMated(Table table, Spot origin, string player) {

            //generate list of all possible blocker moves. try all scenarios. if still NotSafeForKing in all tried scenarios, checkmate

            return false;
        }
    }
}
