using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data.Entities
{
    [Serializable]
    public class ChessPlayer
    {
        public ChessPlayer(string name, int nrOfWins, int nrOfLosses, int nrOfDraws, string matchHistory)
        {            
            Name = name;
            NrOfWins = nrOfWins;
            NrOfLosses = nrOfLosses;
            NrOfDraws = nrOfDraws;
            MatchHistory = matchHistory;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NrOfWins { get; set; }
        public int NrOfLosses { get; set; }
        public int NrOfDraws { get; set; }
        public string MatchHistory { get; set; }

    }

    [Serializable]
    public class PlayerJson
    {
        public ChessPlayer Player { get; set; }
    }
}
