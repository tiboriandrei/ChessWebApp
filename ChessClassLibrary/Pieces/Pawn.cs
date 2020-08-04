using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessClassLibrary;

namespace ChessClassLibrary.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(bool whiteOrNot) : base(whiteOrNot)
        {
        }

        //stanga jos 1,1   x = row , y = column
        //move forward means CoordY minus distance
        //move to the right means CoordX + distance

        public override bool TryMove(Table table, Spot origin, Spot dest, string player)
        {
            if (table.Spots[dest.CoordX, dest.CoordY].Occupied == true)
                {
                    if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == table.Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
                    {
                        return false;
                    }
                    
                    if ( ((dest.CoordX == origin.CoordX - 1) || (dest.CoordX == origin.CoordX + 1)) && (Math.Abs(dest.CoordY - origin.CoordY) == 1))
                    {
                        if (dest.CoordY == 0)
                        {
                            Mediator.GetInstance().OnPawnPromotion(this, new PawnPromotionEventArgs { dest = dest, player = player });
                        }

                        return true; 
                    }

                    return false;                                        
                }

                if (dest.CoordX != origin.CoordX || dest.CoordY > origin.CoordY )
                {
                    return false;                           
                }
                else if (origin.CoordY == 6 && (Math.Abs(dest.CoordY - origin.CoordY) == 2) && (table.Spots[dest.CoordX, Math.Abs(1 - origin.CoordY)].Occupied == false) && (table.Spots[dest.CoordX, Math.Abs(2 - origin.CoordY)].Occupied == false))
                {
                    return true;                               
                }
                else if ((Math.Abs(dest.CoordY - origin.CoordY) == 1) && (table.Spots[dest.CoordX, Math.Abs(1 - origin.CoordY)].Occupied == false))
                {
                    if (dest.CoordY == 0)
                    {
                        Mediator.GetInstance().OnPawnPromotion(this, new PawnPromotionEventArgs { dest = dest, player = player });
                    }

                    return true;    
                }
            
            return false;
        }
            
        //public override string ToString()
        //{
        //    return this.PieceColour.ToString() + "Pawn";
        //}

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

            return table;
        }

    }
}
