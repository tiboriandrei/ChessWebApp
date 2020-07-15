using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class Game
    {
        public Game()
        {
            Table = new ChessTable();

            //get data from db
            string name = "";
            int nrOfWins = 0, nrOfLosses = 0, nrOfDraws = 0;
            //

            Player1 = new Player(name, nrOfWins, nrOfLosses, nrOfDraws);
            Player2 = new Player(name, nrOfWins, nrOfLosses, nrOfDraws);
        }

        public ChessTable Table { get; set; }
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }


    }
}
