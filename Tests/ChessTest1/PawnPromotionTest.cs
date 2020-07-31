using System;
using ChessClassLibrary;
using ChessClassLibrary.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest1
{
    [TestClass]
    public class PawnPromotionTest
    {
        public Game game = new Game(new Player("p1", 0, 0, 0), new Player("p2", 0, 0, 0));

        [TestMethod]
        public void CanPawnCapture()
        {
            game.Table.Spots[1, 1].Piece = new Pawn(true);
            game.Table.Spots[1, 1].Occupied = true;

            bool expected = true;
            bool actual = game.Table.Spots[1, 1].Piece.TryMove(game.Table, new Spot(1, 1), new Spot(0, 0), "White");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EventGetsTriggered()
        {
            game.Table.Spots[1, 1].Piece = new Pawn(true);
            game.Table.Spots[1, 1].Occupied = true;

            game.MovePiece("Pawn", 1, 1, 0, 0, "White");
            
            bool expectedB = true;
            bool actualB = game.evTrig;

            Assert.AreEqual(expectedB, actualB);
        }


        [TestMethod]
        public void PawnEventGetsTriggered()
        {
            game.Table.Spots[1, 1].Piece = new Pawn(true);
            game.Table.Spots[1, 1].Occupied = true;

            game.MovePiece("Pawn", 1,1,0,0, "White");

            string expectedPiece = new Queen(true).ToString();
            string actualPiece = game.Table.Spots[0, 0].Piece.ToString();
            
            Assert.AreEqual(expectedPiece, actualPiece);
        }
    }
}
