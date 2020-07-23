﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Pieces
{
    public class Madman : ChessPiece
    {
        public Madman(bool whiteOrNot) : base(whiteOrNot)
        {

        }
          
        public override bool TryMove(Table table, Spot origin, Spot dest, string player)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.PieceColour.ToString() + "Madman";
        }
    }
}
