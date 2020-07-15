using System;
using System.Collections.Generic;
using ChessClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest1
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerStatsTestValid()
        {
            //arange
            List<string> matchHistory = new List<string>();
            Player player1 = new Player("Andrei", 0,1,0);

            string expected = "0 Wins, 1 Losses, 0 Draws.";

            //act
            string actual = player1.Stats;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
