using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    public class PawnPromotionEventArgs : EventArgs
    {
        public Spot dest { get; set; }
        public string player { get; set; }
    }

    public class PlayerMoveEventArgs : EventArgs
    {
        public Spot origin { get; set; }
        public Spot dest { get; set; }
    }       

    public sealed class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();
        private Mediator() { }

        public static Mediator GetInstance() {
            return _Instance;
        }

        // ----------------------------------------------------------------

        public event EventHandler<PawnPromotionEventArgs> PawnPromotion;
        public void OnPawnPromotion(object sender, PawnPromotionEventArgs e)
        {
            PawnPromotion?.Invoke(this, e);
        }

        // ----------------------------------------------------------------

        public event EventHandler<PlayerMoveEventArgs> PlayerMoves;
        public void OnPlayerMoves(object sender, PlayerMoveEventArgs e)
        {
            PlayerMoves?.Invoke(sender, e);
        }

    }
}
