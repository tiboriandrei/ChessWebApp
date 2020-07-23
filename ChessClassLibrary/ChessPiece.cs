﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public abstract class ChessPiece
    {
        public enum PieceStateOption
        {
            Captured,
            Ready
        }

        public enum PieceColourOption
        {
            Black,
            White
        }
        
        public PieceStateOption PieceState { get; set; }
        public PieceColourOption PieceColour { get; set; }

        public ChessPiece(bool whiteOrNot) {
            if (whiteOrNot)
            {
                this.PieceColour = PieceColourOption.White;
            }            
        }

        public bool IsWhite() {
            return this.PieceColour == PieceColourOption.White;
        }

        public bool IsCaptured() {
            return this.PieceState == PieceStateOption.Captured;
        }

        public abstract bool TryMove(Table table, Spot origin, Spot dest, string player);
               
    }
}
