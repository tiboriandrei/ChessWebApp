using ChessClassLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public delegate void PawnPromotionHandler(object sender, PawnPromotionEventArgs e);
    
    public class Game
    {      
        public Table Table { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        private bool WhiteKingIsInCheck { get; set; }
        private bool BlackKingIsInCheck { get; set; }

        public bool evTrig { get; set; }

        public void PromotePawn(object sender, PawnPromotionEventArgs e) {
            evTrig = true;
            bool color = false;
            if (e.player == "White")
            {
                color = true;
            }

            this.Table.Spots[e.dest.CoordX, e.dest.CoordY].Piece = new Queen(color);
        }

        public Game(Player p1, Player p2)
        {
            this.Table = new Table();
            this.Player1 = p1;
            this.Player2 = p2;
            this.evTrig = false;

            Mediator.GetInstance().PawnPromotion += PromotePawn;           
        }

        public Game(Player p1, Player p2, Table restoredTable)
        {
            this.Table = restoredTable;
            this.Player1 = p1;
            this.Player2 = p2;
            this.evTrig = false;

            //Mediator.GetInstance().PawnPromotion += (s, e) =>
            //{
            //    PromotePawn(s, e);
            //};

            Mediator.GetInstance().PawnPromotion += PromotePawn;
        }


        enum moveType
        {
            goodMove,
            illegalMove,
            kingIsInCheck
        };

        public string MovePiece(string piece, int originX, int originY, int destX, int destY, string player)
        {
            string result = "illegalMove";
            if (player == "Black")
            {
                originX = 7 - originX;
                originY = 7 - originY;
                destX = 7 - destX;
                destY = 7 - destY;
                this.Table = flipTable(this.Table);
            }

            var origin = new Spot(originX, originY);
            var dest = new Spot(destX, destY);
            //var auxSpot = new Spot(0,0);

            bool goodMove = Table.Spots[origin.CoordX, origin.CoordY].Piece.TryMove(Table, origin, dest, player);

            if (goodMove)
            {
                result = "goodMove";
                Table.Spots[dest.CoordX, dest.CoordY].Piece = Table.Spots[origin.CoordX, origin.CoordY].Piece;
                Table.Spots[dest.CoordX, dest.CoordY].Occupied = true;

                Table.Spots[origin.CoordX, origin.CoordY].Piece = null;
                Table.Spots[origin.CoordX, origin.CoordY].Occupied = false;
            }

            if (goodMove)
            {
                foreach (Spot spot in Table.Spots)
                {
                    if (spot.Occupied)
                    {
                        if (player == "Black")
                        {
                            this.Table = flipTable(this.Table);
                            this.Table = spot.Piece.MarkAttackedSpots(this.Table, new Spot(7 - spot.CoordX, 7 - spot.CoordY), spot.Piece.PieceColour.ToString());
                            this.Table = flipTable(this.Table);
                        }
                        else if (player == "White")
                        {
                            this.Table = spot.Piece.MarkAttackedSpots(this.Table, new Spot(spot.CoordX, spot.CoordY), spot.Piece.PieceColour.ToString());
                        }                        
                    }
                }

                foreach (Spot spot in Table.Spots)
                {
                    if (spot.Occupied)
                    {
                        if (player == "White" && spot.Piece.ToString() == "WhiteKing" && spot.NotSafeForWK)
                        {
                           result = "WK_IsInCheck";
                        }

                        if (player == "Black" && spot.Piece.ToString() == "BlackKing" && spot.NotSafeForBK)
                        {
                           result = "BK_IsInCheck";
                        }
                    }                   
                }
            }

            if (result == "WK_IsInCheck" || result == "BK_IsInCheck")
            {                
                Table.Spots[origin.CoordX, origin.CoordY].Piece = Table.Spots[dest.CoordX, dest.CoordY].Piece;
                Table.Spots[origin.CoordX, origin.CoordY].Occupied = true;

                Table.Spots[dest.CoordX, dest.CoordY].Piece = null;
                Table.Spots[dest.CoordX, dest.CoordY].Occupied = false;
            }

            if (player == "Black")
            {
                this.Table = flipTable(this.Table);
            }

            return result;
        }

        public bool IsChecked(Spot kingPos, string opponent)
        {
            //horseman check
            if (kingPos.CoordX - 1 >= 0 && kingPos.CoordY - 2 >= 0)
            {
                if (Table.Spots[kingPos.CoordX - 1, kingPos.CoordY - 2].Occupied)
                {
                    if (Table.Spots[kingPos.CoordX - 1, kingPos.CoordY - 2].Piece.ToString() == opponent + "Horseman")
                    {
                        return true;
                    }
                }
                
            }

            if (kingPos.CoordX - 1 >= 0 && kingPos.CoordY + 2 <= 7)
            {
                if (Table.Spots[kingPos.CoordX - 1, kingPos.CoordY + 2].Occupied)
                {
                    if (Table.Spots[kingPos.CoordX - 1, kingPos.CoordY + 2].Piece.ToString() == opponent + "Horseman")
                    {
                        return true;
                    }
                }
            }

            if (kingPos.CoordX + 1 <= 7 && kingPos.CoordY - 2 >= 0)
            {
                if (Table.Spots[kingPos.CoordX + 1, kingPos.CoordY - 2].Occupied)
                {
                    if (Table.Spots[kingPos.CoordX + 1, kingPos.CoordY - 2].Piece.ToString() == opponent + "Horseman")
                    {
                        return true;
                    }
                }
            }

            if (kingPos.CoordX + 1 <= 7 && kingPos.CoordY + 2 <= 7)
            {
                if (Table.Spots[kingPos.CoordX + 1, kingPos.CoordY + 2].Occupied)
                {
                    if (Table.Spots[kingPos.CoordX + 1, kingPos.CoordY + 2].Piece.ToString() == opponent + "Horseman")
                    {
                        return true;
                    }
                }
            }

            //pawns check
            if (kingPos.CoordX + 1 <= 7 && kingPos.CoordY + 1 <= 7)
            {
                if (Table.Spots[kingPos.CoordX + 1, kingPos.CoordY + 1].Occupied)
                {
                    if (Table.Spots[kingPos.CoordX + 1, kingPos.CoordY + 1].Piece.ToString() == opponent + "Pawn")
                    {
                        return true;
                    }
                }
            }

            if (kingPos.CoordX - 1 >= 0 && kingPos.CoordY + 1 <= 7)
            {
                if (Table.Spots[kingPos.CoordX - 1, kingPos.CoordY + 1].Occupied)
                {
                    if (Table.Spots[kingPos.CoordX - 1, kingPos.CoordY + 1].Piece.ToString() == opponent + "Pawn")
                    {
                        return true;
                    }
                }
            }

            /////////////

            for (int i = 1; i < 8; i++)
            {
                if (kingPos.CoordX + i <= 7)
                {
                    if (Table.Spots[kingPos.CoordX + i, kingPos.CoordY].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX + i, kingPos.CoordY].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX + i, kingPos.CoordY].Piece.ToString() == opponent + "Rook")
                        {
                            return true;
                        }
                    }
                }

                if (kingPos.CoordX - i >= 0)
                {
                    if (Table.Spots[kingPos.CoordX - i, kingPos.CoordY].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX - i, kingPos.CoordY].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX - i, kingPos.CoordY].Piece.ToString() == opponent + "Rook")
                        {
                            return true;
                        }
                    }
                }

                if (kingPos.CoordY + i <= 7)
                {
                    if (Table.Spots[kingPos.CoordX, kingPos.CoordY + i].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX, kingPos.CoordY + i].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX, kingPos.CoordY + i].Piece.ToString() == opponent + "Rook")
                        {
                            return true;
                        }
                    }
                }

                if (kingPos.CoordY - i >= 0)
                {
                    if (Table.Spots[kingPos.CoordX, kingPos.CoordY - i].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX, kingPos.CoordY - i].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX, kingPos.CoordY - i].Piece.ToString() == opponent + "Rook")
                        {
                            return true;
                        }
                    }
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (kingPos.CoordX + i <= 7 && kingPos.CoordY + i <= 7)
                {
                    if (Table.Spots[kingPos.CoordX + i, kingPos.CoordY + i].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX + i, kingPos.CoordY + i].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX + i, kingPos.CoordY + i].Piece.ToString() == opponent + "Madman")
                        {
                            return true;
                        }
                    }
                }

                if (kingPos.CoordX - i >= 0 && kingPos.CoordY + i <= 7)
                {
                    if (Table.Spots[kingPos.CoordX - i, kingPos.CoordY + i].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX - i, kingPos.CoordY + i].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX - i, kingPos.CoordY + i].Piece.ToString() == opponent + "Madman")
                        {
                            return true;
                        }
                    }
                }

                if (kingPos.CoordX + i <= 7 && kingPos.CoordY - i >= 0)
                {
                    if (Table.Spots[kingPos.CoordX + i, kingPos.CoordY - i].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX + i, kingPos.CoordY - i].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX + i, kingPos.CoordY - i].Piece.ToString() == opponent + "Madman")
                        {
                            return true;
                        }
                    }
                }

                if (kingPos.CoordX - i >= 0 && kingPos.CoordY - i >= 0)
                {
                    if (Table.Spots[kingPos.CoordX - i, kingPos.CoordY - i].Occupied)
                    {
                        if (Table.Spots[kingPos.CoordX - i, kingPos.CoordY - i].Piece.ToString() == opponent + "Queen"
                        || Table.Spots[kingPos.CoordX - i, kingPos.CoordY - i].Piece.ToString() == opponent + "Madman")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public Table flipTable(Table table)
        {
            Table flippedTable = new Table();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {                    
                    flippedTable.Spots[i, j] = table.Spots[7 - i, 7 - j];
                    flippedTable.Spots[i, j].CoordX = 7 - i;
                    flippedTable.Spots[i, j].CoordY = 7 - j;
                }
            }
            return flippedTable;
        }

    }
}
