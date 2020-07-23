using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(bool whiteOrNot) : base(whiteOrNot)
        {
        }

        //stanga jos 1,1   x = row , y = column

        public override bool TryMove(Table table, Spot origin, Spot dest, string player)
        {

            if (player == "white")
            {
                if (table.Spots[dest.CoordX, dest.CoordY].Occupied == true)
                {
                    if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == table.Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
                    {
                        return false;
                    }

                    if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour.ToString() == "Black")
                    {
                        if ( ((dest.CoordX == origin.CoordX - 1) || (dest.CoordX == origin.CoordX + 1)) && (Math.Abs(dest.CoordY - origin.CoordY) == 1))
                        {
                            return true;
                        }

                        return false;
                    }                    
                }

                if (dest.CoordX != origin.CoordX)
                {
                    return false;
                }
                else if ((Math.Abs(dest.CoordY - origin.CoordY) == 2) && (table.Spots[dest.CoordX, Math.Abs(1 - origin.CoordY)].Occupied == false) && (table.Spots[dest.CoordX, Math.Abs(2 - origin.CoordY)].Occupied == false))
                {
                    return true;
                }
                else if ((Math.Abs(dest.CoordY - origin.CoordY) == 1) && (table.Spots[dest.CoordX, Math.Abs(1 - origin.CoordY)].Occupied == false))
                {
                    return true;
                }
            }

            else if(player == "black") {

                if (table.Spots[dest.CoordX, dest.CoordY].Occupied == true)
                {
                    if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour == table.Spots[origin.CoordX, origin.CoordY].Piece.PieceColour)
                    {
                        return false;
                    }

                    if (table.Spots[dest.CoordX, dest.CoordY].Piece.PieceColour.ToString() == "White")
                    {
                        if (((dest.CoordX == origin.CoordX - 1) || (dest.CoordX == origin.CoordX + 1)) && (Math.Abs(dest.CoordY - origin.CoordY) == 1))
                        {
                            return true;
                        }

                        return false;
                    }                   
                }

                if (dest.CoordX != origin.CoordX)
                {
                    return false;
                }
                else if ((Math.Abs(dest.CoordY - origin.CoordY) == 2) && (table.Spots[dest.CoordX, Math.Abs(1 + origin.CoordY)].Occupied == false) && (table.Spots[dest.CoordX, Math.Abs(2 + origin.CoordY)].Occupied == false))
                {
                    return true;
                }
                else if ((Math.Abs(dest.CoordY - origin.CoordY) == 1) && (table.Spots[dest.CoordX, Math.Abs(1 + origin.CoordY)].Occupied == false))
                {
                    return true;
                }
            }
            

            return false;
        }

        public override string ToString()
        {
            return this.PieceColour.ToString() + "Pawn";
        }
    }
}
