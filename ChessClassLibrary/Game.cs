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
            var origin = new Spot(originX, originY);
            var dest = new Spot(destX, destY);
            
            return Table.Spots[origin.CoordX, origin.CoordY].Piece.TryMove(Table, origin, dest, player); 
        }
    }
}
