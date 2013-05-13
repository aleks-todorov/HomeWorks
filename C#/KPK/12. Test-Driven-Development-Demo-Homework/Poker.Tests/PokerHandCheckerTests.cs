using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandCheckerTests
    {
        [TestMethod]
        public void IsValidHandWithSameCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsValidHand(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidHandWithDifferentCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Hearts),  
                new Card(CardFace.King,CardSuit.Spades)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsValidHand(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidHandWithCardsWithSameFace()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                 new Card(CardFace.Ten,CardSuit.Diamonds)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsValidHand(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFlushWithInvalidHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFlushWithDifferentSuits()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.Three,CardSuit.Hearts),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Diamonds),
                new Card(CardFace.Six,CardSuit.Spades)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFlushWithSameSuits()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.Three,CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Clubs),
                new Card(CardFace.Six,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFlushWithWithAceInBeggining()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.Three,CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFlushWithRoyalFlushCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFlushWithSequenceOfTenAndJack()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Clubs),
                new Card(CardFace.Eight,CardSuit.Clubs),
                new Card(CardFace.Nine,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFlushWithSequenceOfTenAndJackNotSorted()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Nine,CardSuit.Clubs),
                new Card(CardFace.Seven,CardSuit.Clubs),  
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Clubs), 
                new Card(CardFace.Eight,CardSuit.Clubs), 
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsStraightFlush(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithInvalidHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Diamonds)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithValidHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithFourSameCardsWithSameSuit()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Clubs),
                 new Card(CardFace.King,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithTwoSameCardsWithSameSuit()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Clubs),
                 new Card(CardFace.King,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithTwoPairs()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ten,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Clubs),
                 new Card(CardFace.King,CardSuit.Clubs)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithDifferentCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ten,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Two,CardSuit.Clubs) 
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsFourOfAKindWithFourSameUnsorted()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ace,CardSuit.Spades)
            });
            var handChecker = new PokerHandsChecker();
            var isValid = handChecker.IsFourOfAKind(hand);
            Assert.IsTrue(isValid);
        }
    }
}
