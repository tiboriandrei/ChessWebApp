using ChessClassLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class Table
    {
        public Spot[,] Spots { get; set; }
        //public List<ChessPiece> CapturedPieces { get; set; }        

        public Table() {

            this.Spots = new Spot[8,8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Spots[i, j] = new Spot(i, j);                    
                }
            }
            
            //adding pawns
            for (int i = 0; i < 8; i++)
            {
                Spots[i, 1].Piece = new Pawn(false);
                Spots[i, 1].Occupied = true;                   
            }

            for (int i = 0; i < 8; i++)
            {
                Spots[i, 6].Piece = new Pawn(true);
                Spots[i, 6].Occupied = true;
            }

            //black non-pawn pieces
            Spots[0, 0].Piece = new Rook(false);
            Spots[0, 0].Occupied = true;
            Spots[7, 0].Piece = new Rook(false);
            Spots[7, 0].Occupied = true;

            Spots[1, 0].Piece = new Horseman(false);
            Spots[1, 0].Occupied = true;
            Spots[6, 0].Piece = new Horseman(false);
            Spots[6, 0].Occupied = true;

            Spots[2, 0].Piece = new Madman(false);
            Spots[2, 0].Occupied = true;
            Spots[5, 0].Piece = new Madman(false);
            Spots[5, 0].Occupied = true;

            Spots[3, 0].Piece = new King(false);
            Spots[3, 0].Occupied = true;
            Spots[4, 0].Piece = new Queen(false);
            Spots[4, 0].Occupied = true;

            //white non-pawn pieces
            Spots[0, 7].Piece = new Rook(true);
            Spots[0, 7].Occupied = true;
            Spots[7, 7].Piece = new Rook(true);
            Spots[7, 7].Occupied = true;

            Spots[1, 7].Piece = new Horseman(true);
            Spots[1, 7].Occupied = true;
            Spots[6, 7].Piece = new Horseman(true);
            Spots[6, 7].Occupied = true;

            Spots[2, 7].Piece = new Madman(true);
            Spots[2, 7].Occupied = true;
            Spots[5, 7].Piece = new Madman(true);
            Spots[5, 7].Occupied = true;

            Spots[3, 7].Piece = new King(true);
            Spots[3, 7].Occupied = true;
            Spots[4, 7].Piece = new Queen(true);
            Spots[4, 7].Occupied = true;
        }
        
        public Table(List<Spot> list) {

            this.Spots = new Spot[8, 8];

            foreach (var spot in list)
            {
                Spots[spot.CoordX, spot.CoordY] = spot; 
            }            
        }

    }
}
