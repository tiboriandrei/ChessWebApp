using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data.Entities
{
    public class ChessSpot
    {
        public ChessSpot(string piece, bool occupied, int coordX, int coordY)
        {
            Piece = piece;
            Occupied = occupied;
            CoordX = coordX;
            CoordY = coordY;
        }

        public int Id { get; set; }
        public string Piece { get; set; }       
        public bool Occupied { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
    }
}
