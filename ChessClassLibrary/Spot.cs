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

        public Spot(int x, int y)
        {
            Piece = null;
            Occupied = false;
            CoordX = x;
            CoordY = y;
            
            NotSafeForWK = false;
            NotSafeForBK = false;
        }

        public Spot(int x, int y, ChessPiece piece, bool occupied)
        {
            CoordX = x;
            CoordY = y;
            Piece = piece;
            Occupied = occupied;

            NotSafeForWK = false;
            NotSafeForBK = false;
        }

    }
}
