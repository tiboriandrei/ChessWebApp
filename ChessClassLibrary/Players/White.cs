using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary.Players
{
    public class White : Player
    {
        public White(string name, int nrOfWins, int nrOfLosses, int nrOfDraws) : base(name, nrOfWins, nrOfLosses, nrOfDraws)
        {

        }

        public override void DoAMove(Spot origin, Spot dest)
        {
            Mediator.GetInstance().OnPlayerMoves(this, new PlayerMoveEventArgs { dest = dest, origin = origin });
        }
    }
}
