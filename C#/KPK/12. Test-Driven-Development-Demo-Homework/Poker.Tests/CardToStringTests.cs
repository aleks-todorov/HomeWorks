using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void ToStringOfSevenHearts()
        {
            Card card = new Card(CardFace.Seven, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("7♥", result);
        }

        [TestMethod]
        public void ToStringOfJackOfDiamonds()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("J♦", result);
        }

        [TestMethod]
        public void ToStringOfAceOfSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string result = card.ToString();
            Assert.AreEqual("A♠", result);
        }

        [TestMethod]
        public void ToStringOfQueenOfClubs()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("Q♣", result);
        }

        [TestMethod]
        public void ToStringOfTenOfClubs()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("10♣", result);
        }
    }
}
