using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data.Entities
{
    public class ChessTable
    {
        [Key]
        public int Id { get; set; }
        public List<ChessSpot> Spots { get; set; }
        //private List<string> CapturedPieces { get; set; }
        //private List<string> Pieces { get; set; }
    }
}
