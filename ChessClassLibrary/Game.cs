using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class Game
    {        
        public Table Table { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game(Player p1, Player p2)
        {
            this.Table = new Table();
            this.Player1 = p1;
            this.Player2 = p2;
        }

        public Game(Player p1, Player p2, Table restoredTable)
        {
            this.Table = restoredTable;
            this.Player1 = p1;
            this.Player2 = p2;
        }

        public bool MovePiece(string piece, int originX, int originY, int destX, int destY, string player)
        {
            //if (player == "Black")
            //{
            //    originX = 7 - originX;
            //    originY = 7 - originY;
            //    destX = 7 - destX;
            //    destY = 7 - destY;
            //    this.Table = flipTable(this.Table);
            //}

            var origin = new Spot(originX, originY);
            var dest = new Spot(destX, destY);

            bool goodMove = Table.Spots[origin.CoordX, origin.CoordY].Piece.TryMove(Table, origin, dest, player);

            //if (player == "Black")
            //{
            //    this.Table = flipTable(this.Table);
            //}
            
            return goodMove;
        }


        public Table flipTable(Table table)
        {
            Table flippedTable = new Table();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {                    
                    flippedTable.Spots[i, j] = table.Spots[i, 7 - j];
                }
            }
            return flippedTable;
        }

    }
}
