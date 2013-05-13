using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var card in this.Cards)
            {
                sb.AppendFormat("{0} ", card.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
