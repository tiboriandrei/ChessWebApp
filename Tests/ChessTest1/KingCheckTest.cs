using System;
using ChessClassLibrary;
using ChessClassLibrary.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest1
{
    [TestClass]
    public class KingCheckTest
    {
        //public Game game = new Game(new Player("p1", 0, 0, 0), new Player("p2", 0, 0, 0));

        //[TestMethod]
        //public void WhiteKingCheckTest()
        //{
        //    game.Table.Spots[5, 6].Piece = new Horseman(false);     //black horseman
        //    game.Table.Spots[5, 6].Occupied = true;
            
        //    //game.Table.Spots[6, 4].Piece = new Queen(false);     //black queen
        //    //game.Table.Spots[6, 4].Occupied = true;

        //    game.Table.Spots[4, 6].Piece = null;     
        //    game.Table.Spots[4, 6].Occupied = false;

        //    string expected = "WK_IsInCheck";

        //    string actual = game.MovePiece("Pawn", 3, 6, 3, 5, "White");

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void BlackKingCheckTest()
        //{
        //    //game.Table.Spots[2, 2].Piece = new Horseman(true);     
        //    //game.Table.Spots[2, 2].Occupied = true;

        //    game.Table.Spots[3, 5].Piece = new Queen(true);   
        //    game.Table.Spots[3, 5].Occupied = true;

        //    game.Table.Spots[3, 1].Piece = null;
        //    game.Table.Spots[3, 1].Occupied = false;

        //    string expected = "BK_IsInCheck";

        //    string actual = game.MovePiece("Horseman", 1, 0, 0, 2, "Black");

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
