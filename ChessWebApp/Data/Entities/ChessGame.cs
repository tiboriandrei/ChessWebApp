using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data.Entities
{
    public class ChessGame
    {
        public int Id { get; set; }
        public virtual ChessPlayer Player1 { get; set; }
        public virtual ChessPlayer Player2 { get; set; }
        public virtual ChessTable GameState { get; set; }
        public string Winner { get; set; }
        public DateTime Date { get; set; }
    }

    [Serializable]
    public class GameJson
    {
        public ChessGame Game { get; set; }
    }
}
