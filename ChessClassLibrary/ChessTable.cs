using ChessClassLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class ChessTable
    {
        public Spot[,] Table { get; set; }
        private List<ChessPiece> CapturedPieces { get; set; }
        private List<ChessPiece> Pieces { get; set; }

        public ChessTable() {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Table[i, j] = new Spot();
                }
            }
            
            //adding pawns
            for (int i = 0; i < 8; i++)
            {
                Table[i, 1].Piece = new Pawn(false);                   
                Table[i, 1].Occupied = true;                   
            }

            for (int i = 0; i < 8; i++)
            {
                Table[i, 7].Piece = new Pawn(true);
                Table[i, 7].Occupied = true;
            }

            //black non-pawn pieces
            Table[1, 0].Piece = new Rook(false);
            Table[1, 0].Occupied = true;
            Table[8, 0].Piece = new Rook(false);
            Table[8, 0].Occupied = true;            

            Table[2, 0].Piece = new Horseman(false);
            Table[2, 0].Occupied = true;
            Table[7, 0].Piece = new Horseman(false);
            Table[7, 0].Occupied = true;
                
            Table[3, 0].Piece = new Madman(false);
            Table[3, 0].Occupied = true;
            Table[6, 0].Piece = new Madman(false);
            Table[6, 0].Occupied = true;

            Table[4, 0].Piece = new King(false);
            Table[4, 0].Occupied = true;
            Table[5, 0].Piece = new Queen(false);
            Table[5, 0].Occupied = true;

            //white non-pawn pieces
            Table[1, 8].Piece = new Rook(true);
            Table[1, 8].Occupied = true;
            Table[8, 8].Piece = new Rook(true);
            Table[8, 8].Occupied = true;

            Table[2, 8].Piece = new Horseman(true);
            Table[2, 8].Occupied = true;
            Table[7, 8].Piece = new Horseman(true);
            Table[7, 8].Occupied = true;

            Table[3, 8].Piece = new Madman(true);
            Table[3, 8].Occupied = true;
            Table[6, 8].Piece = new Madman(true);
            Table[6, 8].Occupied = true;

            Table[4, 8].Piece = new King(true);
            Table[4, 8].Occupied = true;
            Table[5, 8].Piece = new Queen(true);
            Table[5, 8].Occupied = true;
        }

        public bool MovePiece(string piece, int originColumn, int originRow, int destColumn, int destRow, string player) {

            Table[originRow, originColumn].Piece.TryMove(destRow, destColumn, player);

            return true;
        }

        public bool RemovePiece()
        {
            return true;
        }

    }
}
