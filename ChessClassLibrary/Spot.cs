using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class Spot
    {
        public ChessPiece Piece { get; set; }
        public bool Occupied { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public bool NotSafeForWK { get; set; }
        public bool NotSafeForBK { get; set; }
       

        public Spot(int i, int j)
        {
            Piece = null;
            Occupied = false;
            CoordX = i;
            CoordY = j;
            
            NotSafeForWK = false;
            NotSafeForBK = false;
        }

        public Spot(ChessPiece piece, bool occupied)
        {
            Piece = piece;
            Occupied = occupied;
        }

        public Spot(int i, int j, ChessPiece piece, bool occupied)
        {
            CoordX = i;
            CoordY = j;
            Piece = piece;
            Occupied = occupied;
        }

        public void ChangeState(ChessPiece piece)
        {
            this.Piece = piece;
            if (piece == null)
            {
                this.Occupied = false;
            }
        }

        
    }
}
