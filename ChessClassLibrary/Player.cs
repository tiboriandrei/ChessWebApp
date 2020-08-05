using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public abstract class Player
    {
        public string Name { get; set; }
        public int NrOfWins { get; set; }
        public int NrOfLosses { get; set; }
        public int NrOfDraws { get; set; }
        public List<string> MatchHistory { get; set; }

        public Player(string name, int nrOfWins, int nrOfLosses, int nrOfDraws)
        {
            Name = name;
            NrOfWins = nrOfWins;
            NrOfLosses = nrOfLosses;
            NrOfDraws = nrOfDraws;
            MatchHistory = new List<string>();
        }

        public abstract void DoAMove(Spot origin, Spot dest);        

        public string Stats {
            get {
                return NrOfWins.ToString() + " Wins, " + NrOfLosses.ToString() + " Losses, " + NrOfDraws.ToString() + " Draws.";
            }
        }

        public void IncrNrOfWins()
        {
           this.NrOfWins++;
        }

        public void IncrNrOfLosses()
        {
            this.NrOfLosses++;
        }

        public void IncrNrOfDraws()
        {
            this.NrOfDraws++;
        }

        public void AddMatchToHistory(string match)
        {
            this.MatchHistory.Add(match);
        }
    }
}
