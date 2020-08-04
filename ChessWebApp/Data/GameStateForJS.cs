using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data
{
    public class GameStateForJS
    {
        public GameStateForJS(string piece, string color, int coordX, int coordY)
        {
            Piece = piece;
            Color = color;
            CoordX = coordX;
            CoordY = coordY;
        }
        public string Piece { get; set; }
        public string Color { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
    }
}
