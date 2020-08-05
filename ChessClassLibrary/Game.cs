using ChessClassLibrary.Pieces;
using ChessClassLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class Game
    {
        public Table Table { get; set; }
        public White White { get; set; }
        public Black Black { get; set; }        
        public string PlayerTurn { get; set; } = "White";
        public string MoveResult { get; set; }
       
        public Game(Player p1, Player p2)
        {
            this.Table = new Table();
            this.White = (White)p1;
            this.Black = (Black)p2;
                        
            //Mediator.GetInstance().Result += GetResult;
            //Mediator.GetInstance().PlayerMoves += Move;        
        }

        public Game(Player p1, Player p2, Table restoredTable)
        {
            this.Table = restoredTable; 
            this.White = (White)p1;
            this.Black = (Black)p2;
                        
            Mediator.GetInstance().Result += GetResult;
        }

        //private Table flipTable(Table table)
        //{
        //    Table flippedTable = new Table();

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {                    
        //            flippedTable.Spots[i, j] = table.Spots[7 - i, 7 - j];
        //            flippedTable.Spots[i, j].CoordX = 7 - i;
        //            flippedTable.Spots[i, j].CoordY = 7 - j;
        //        }
        //    }
        //    return flippedTable;
        //}

        //public void Move(object sender, PlayerMoveEventArgs e)
        //{
        //    string result = "illegalMove";
        //    ChessPiece attackedPiece;

        //    if (sender.GetType().Name == "Black")
        //    {
        //        e.origin.CoordX = 7 - e.origin.CoordX;
        //        e.origin.CoordY = 7 - e.origin.CoordY;
        //        e.dest.CoordX = 7 - e.origin.CoordX;
        //        e.dest.CoordY = 7 - e.dest.CoordY;
        //        this.Table = flipTable(this.Table);
        //    }

        //    var origin = new Spot(e.origin.CoordX, e.origin.CoordY);
        //    var dest = new Spot(e.dest.CoordX, e.dest.CoordY);

        //    attackedPiece = Table.Spots[dest.CoordX, dest.CoordY].Piece;

        //    bool goodMove = Table.Spots[origin.CoordX, origin.CoordY].Piece.TryMove(Table, origin, dest, sender.GetType().Name);

        //    if (goodMove)
        //    {
        //        result = "goodMove";

        //        Table.Spots[dest.CoordX, dest.CoordY].Piece = Table.Spots[origin.CoordX, origin.CoordY].Piece;
        //        Table.Spots[dest.CoordX, dest.CoordY].Occupied = true;

        //        Table.Spots[origin.CoordX, origin.CoordY].Piece = null;
        //        Table.Spots[origin.CoordX, origin.CoordY].Occupied = false;

        //        foreach (Spot spot in Table.Spots)
        //        {
        //            if (spot.Occupied)
        //            {
        //                if (sender.GetType().Name == "Black")
        //                {
        //                    this.Table = flipTable(this.Table);
        //                    this.Table = spot.Piece.MarkAttackedSpots(this.Table, new Spot(7 - spot.CoordX, 7 - spot.CoordY), spot.Piece.PieceColour.ToString());
        //                    this.Table = flipTable(this.Table);
        //                }
        //                else if (sender.GetType().Name == "White")
        //                {
        //                    this.Table = spot.Piece.MarkAttackedSpots(this.Table, new Spot(spot.CoordX, spot.CoordY), spot.Piece.PieceColour.ToString());
        //                }
        //            }
        //        }

        //        foreach (Spot spot in Table.Spots)
        //        {
        //            if (spot.Occupied)
        //            {
        //                if (sender.GetType().Name == "White" && spot.Piece.ToString() == "WhiteKing" && spot.NotSafeForWK)
        //                {
        //                    result = "WK_IsInCheck";
        //                }

        //                if (sender.GetType().Name == "Black" && spot.Piece.ToString() == "BlackKing" && spot.NotSafeForBK)
        //                {
        //                    result = "BK_IsInCheck";
        //                }
        //            }
        //        }
        //    }

        //    if (result == "WK_IsInCheck" || result == "BK_IsInCheck")
        //    {
        //        Table.Spots[origin.CoordX, origin.CoordY].Piece = Table.Spots[dest.CoordX, dest.CoordY].Piece;
        //        Table.Spots[origin.CoordX, origin.CoordY].Occupied = true;

        //        Table.Spots[dest.CoordX, dest.CoordY].Piece = attackedPiece;
        //        Table.Spots[dest.CoordX, dest.CoordY].Occupied = false;
        //    }

        //    if (promoteEventCalled && result == "goodMove")
        //    {
        //        Table.Spots[dest.CoordX, dest.CoordY].Piece = new Queen(sender.GetType().Name == "White");
        //        Table.Spots[dest.CoordX, dest.CoordY].Occupied = false;
        //        promoteEventCalled = false;
        //    }

        //    if (sender.GetType().Name == "Black")
        //    {
        //        this.Table = flipTable(this.Table);
        //    }

        //    MoveResult = result;
        //}
                
        public void PromotePawn(object sender, PawnPromotionEventArgs e)
        {
            //bool color = false;
            //if (e.player == "White")
            //{
            //    color = true;
            //}

            //this.Table.Spots[e.dest.CoordX, e.dest.CoordY].Piece = new Queen(color);
        }

        public void GetResult(object sender, string e)
        {
            MoveResult = e;
            Mediator.GetInstance().Result -= GetResult;
        }
    }

    //public string MovePiece(string piece, int originX, int originY, int destX, int destY, string player)
    //{
    //    string result = "illegalMove";
    //    ChessPiece attackedPiece;

    //    if (player == "Black")
    //    {
    //        originX = 7 - originX;
    //        originY = 7 - originY;
    //        destX = 7 - destX;
    //        destY = 7 - destY;
    //        this.Table = flipTable(this.Table);
    //    }

    //    var origin = new Spot(originX, originY);
    //    var dest = new Spot(destX, destY);
    //    attackedPiece = Table.Spots[dest.CoordX, dest.CoordY].Piece;

    //    bool goodMove = Table.Spots[origin.CoordX, origin.CoordY].Piece.TryMove(Table, origin, dest, player);

    //    if (goodMove)
    //    {
    //        result = "goodMove";

    //        Table.Spots[dest.CoordX, dest.CoordY].Piece = Table.Spots[origin.CoordX, origin.CoordY].Piece;
    //        Table.Spots[dest.CoordX, dest.CoordY].Occupied = true;

    //        Table.Spots[origin.CoordX, origin.CoordY].Piece = null;
    //        Table.Spots[origin.CoordX, origin.CoordY].Occupied = false;                

    //        foreach (Spot spot in Table.Spots)
    //        {
    //            if (spot.Occupied)
    //            {
    //                if (player == "Black")
    //                {
    //                    this.Table = flipTable(this.Table);
    //                    this.Table = spot.Piece.MarkAttackedSpots(this.Table, new Spot(7 - spot.CoordX, 7 - spot.CoordY), spot.Piece.PieceColour.ToString());
    //                    this.Table = flipTable(this.Table);
    //                }
    //                else if (player == "White")
    //                {
    //                    this.Table = spot.Piece.MarkAttackedSpots(this.Table, new Spot(spot.CoordX, spot.CoordY), spot.Piece.PieceColour.ToString());
    //                }                        
    //            }
    //        }

    //        foreach (Spot spot in Table.Spots)
    //        {
    //            if (spot.Occupied)
    //            {
    //                if (player == "White" && spot.Piece.ToString() == "WhiteKing" && spot.NotSafeForWK)
    //                {
    //                   result = "WK_IsInCheck";
    //                }

    //                if (player == "Black" && spot.Piece.ToString() == "BlackKing" && spot.NotSafeForBK)
    //                {
    //                   result = "BK_IsInCheck";
    //                }
    //            }                   
    //        }
    //    }

    //    if (result == "WK_IsInCheck" || result == "BK_IsInCheck")
    //    {                
    //        Table.Spots[origin.CoordX, origin.CoordY].Piece = Table.Spots[dest.CoordX, dest.CoordY].Piece;
    //        Table.Spots[origin.CoordX, origin.CoordY].Occupied = true;

    //        Table.Spots[dest.CoordX, dest.CoordY].Piece = attackedPiece;
    //        Table.Spots[dest.CoordX, dest.CoordY].Occupied = false;
    //    }

    //    if (promoteEventCalled && result == "goodMove")
    //    {
    //        Table.Spots[dest.CoordX, dest.CoordY].Piece = new Queen(player == "White");
    //        Table.Spots[dest.CoordX, dest.CoordY].Occupied = false;
    //        promoteEventCalled = false;
    //    }

    //    if (player == "Black")
    //    {
    //        this.Table = flipTable(this.Table);
    //    }

    //    return result;
    //}
}
