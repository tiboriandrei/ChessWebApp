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
        public bool promoteEventCalled { get; private set; }
              
        public Table() {

            //Mediator.GetInstance().PlayerMoves += Move;

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

            Mediator.GetInstance().PlayerMoves += Move;

            this.Spots = new Spot[8, 8];

            foreach (var spot in list)
            {
                Spots[spot.CoordX, spot.CoordY] = spot; 
            }            
        }

        public void Move(object sender, PlayerMoveEventArgs e)
        {
            string result = "illegalMove";
            ChessPiece attackedPiece;

            if (sender.GetType().Name == "Black")
            {
                e.origin.CoordX = 7 - e.origin.CoordX;
                e.origin.CoordY = 7 - e.origin.CoordY;
                e.dest.CoordX = 7 - e.dest.CoordX;
                e.dest.CoordY = 7 - e.dest.CoordY;
                flipTable();
            }

            var origin = new Spot(e.origin.CoordX, e.origin.CoordY);
            var dest = new Spot(e.dest.CoordX, e.dest.CoordY);

            attackedPiece = Spots[dest.CoordX, dest.CoordY].Piece;

            bool goodMove = Spots[origin.CoordX, origin.CoordY].Piece.TryMove(Spots, origin, dest, sender.GetType().Name);

            if (goodMove)
            {
                result = "goodMove";

                Spots[dest.CoordX, dest.CoordY].Piece = Spots[origin.CoordX, origin.CoordY].Piece;
                Spots[dest.CoordX, dest.CoordY].Occupied = true;

                Spots[origin.CoordX, origin.CoordY].Piece = null;
                Spots[origin.CoordX, origin.CoordY].Occupied = false;

                foreach (Spot spot in Spots)
                {
                    if (spot.Occupied)
                    {
                        if (sender.GetType().Name == "Black")
                        {
                            flipTable();
                            Spots = spot.Piece.MarkAttackedSpots(Spots, new Spot(7 - spot.CoordX, 7 - spot.CoordY), spot.Piece.PieceColour.ToString());
                            flipTable();
                        }
                        else if (sender.GetType().Name == "White")
                        {
                            Spots = spot.Piece.MarkAttackedSpots(Spots, new Spot(spot.CoordX, spot.CoordY), spot.Piece.PieceColour.ToString());
                        }
                    }
                }

                foreach (Spot spot in Spots)
                {
                    if (spot.Occupied)
                    {
                        if (sender.GetType().Name == "White" && spot.Piece.ToString() == "WhiteKing" && spot.NotSafeForWK)
                        {
                            result = "WK_IsInCheck";
                        }

                        if (sender.GetType().Name == "Black" && spot.Piece.ToString() == "BlackKing" && spot.NotSafeForBK)
                        {
                            result = "BK_IsInCheck";
                        }
                    }
                }
            }

            if (result == "WK_IsInCheck" || result == "BK_IsInCheck")
            {
                Spots[origin.CoordX, origin.CoordY].Piece = Spots[dest.CoordX, dest.CoordY].Piece;
                Spots[origin.CoordX, origin.CoordY].Occupied = true;

                Spots[dest.CoordX, dest.CoordY].Piece = attackedPiece;
                Spots[dest.CoordX, dest.CoordY].Occupied = false;
            }

            if (promoteEventCalled && result == "goodMove")
            {
                Spots[dest.CoordX, dest.CoordY].Piece = new Queen(sender.GetType().Name == "White");
                Spots[dest.CoordX, dest.CoordY].Occupied = false;
                promoteEventCalled = false;
            }

            if (sender.GetType().Name == "Black")
            {
                flipTable();
            }

            Mediator.GetInstance().PlayerMoves -= Move;
            Mediator.GetInstance().OnResult(this, result);            
        }

        private void flipTable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var aux = Spots[i, j];
                    Spots[i, j] = Spots[7 - i, 7 - j];
                    Spots[7 - i, 7 - j] = aux;
                    //Spots[i, j].CoordX = 7 - i;
                    //Spots[i, j].CoordY = 7 - j;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Spots[i, j].CoordX = i;
                    Spots[i, j].CoordY = j;
                }
            }
        }
    }
}
