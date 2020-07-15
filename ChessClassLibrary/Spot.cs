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

        public Spot()
        {
            Piece = null;
            Occupied = false;
        }

        public Spot(ChessPiece piece, bool occupied)
        {
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
