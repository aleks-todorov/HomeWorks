using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            var isValid = true;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                var currentCard = hand.Cards[i];

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    var nextCard = hand.Cards[j];
                    if (currentCard.Face == nextCard.Face && currentCard.Suit == nextCard.Suit)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid == false)
                {
                    break;
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            var isFlush = true;
            var previousColor = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (previousColor != hand.Cards[i].Suit)
                {
                    isFlush = false;
                    break;
                }
                previousColor = hand.Cards[i].Suit;
            }

            if (isFlush == false)
            {
                return isFlush;
            }

            int[] cards = new int[5];
            var counter = 0;
            foreach (var card in hand.Cards)
            {
                switch (card.Face)
                {
                    case CardFace.Two: cards[counter] = 2;
                        break;
                    case CardFace.Three: cards[counter] = 3;
                        break;
                    case CardFace.Four: cards[counter] = 4;
                        break;
                    case CardFace.Five: cards[counter] = 5;
                        break;
                    case CardFace.Six: cards[counter] = 6;
                        break;
                    case CardFace.Seven: cards[counter] = 7;
                        break;
                    case CardFace.Eight: cards[counter] = 8;
                        break;
                    case CardFace.Nine: cards[counter] = 9;
                        break;
                    case CardFace.Ten: cards[counter] = 10;
                        break;
                    case CardFace.Jack: cards[counter] = 12;
                        break;
                    case CardFace.Queen: cards[counter] = 13;
                        break;
                    case CardFace.King: cards[counter] = 14;
                        break;
                    case CardFace.Ace: cards[counter] = 15;
                        break;
                    default:
                        break;
                }
                counter++;
            }

            Array.Sort(cards);
            var previousCard = cards[0];
            for (int i = 1; i < cards.Length; i++)
            {
                var currentCard = cards[i];
                if (previousCard + 1 != currentCard)
                {
                    if (previousCard == 10 && currentCard == 12)
                    {
                        previousCard = currentCard;
                        continue;
                    }
                    else if (previousCard == 5 && currentCard == 15)
                    {
                        previousCard = currentCard;
                        continue;
                    }
                    else
                    {
                        isFlush = false;
                        break;
                    }
                }
                previousCard = currentCard;
            }
            return isFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            var isFourOfAKind = false;
            var sortedHand = new Hand(hand.Cards);
            sortedHand.Cards = sortedHand.Cards.OrderBy(t => t.Face).ToList();
            var numberOfEqualCards = 1;
            var previousCard = sortedHand.Cards[0];

            // I dont make checks for repeating cards with same suit and face, because  they are                    filtered in the beggining by !IsValidHand(hand)) 
            for (int i = 1; i < sortedHand.Cards.Count; i++)
            {
                var currentCard = sortedHand.Cards[i];
                if (previousCard.Face == currentCard.Face)
                {
                    numberOfEqualCards++;
                }
                previousCard = currentCard;
            }

            if (numberOfEqualCards == 4)
            {
                isFourOfAKind = true;
            }
            return isFourOfAKind;
        }

        //The rest are not mandatory(6* and 7*) for which I dont have time atm. 
        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
