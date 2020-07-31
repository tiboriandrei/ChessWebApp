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

    public sealed class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();
        private Mediator() { }

        public static Mediator GetInstance() {
            return _Instance;
        }

        public event EventHandler<PawnPromotionEventArgs> PawnPromotion;

        public void OnPawnPromotion(object sender, PawnPromotionEventArgs e)
        {
            EventHandler<PawnPromotionEventArgs> handler = PawnPromotion;
            handler?.Invoke(this, new PawnPromotionEventArgs { dest = e.dest, player = e.player });
        }

        public void _OnPawnPromotion(PawnPromotionEventArgs args)
        {
            EventHandler<PawnPromotionEventArgs> handler = PawnPromotion;
           // handler?.Invoke(this, new PawnPromotionEventArgs { dest = args.dest, player = args.player });


            if (handler!=null)
            {
                handler(this, args);
            }
           
        }



    }
}
