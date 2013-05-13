using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandToStringTests
    {
        [TestMethod]
        public void ToStringWithNoCards()
        {
            var hand = new Hand(new List<ICard>());
            var result = hand.ToString();
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ToStringWithOneCard()
        {
            var hand = new Hand(new List<ICard>() { new Card(CardFace.Ace, CardSuit.Spades) });
            var result = hand.ToString();
            Assert.AreEqual("A♠", result);
        } 

        [TestMethod]
        public void ToStringWithFiveCard()
        {
            var hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
            });

            Assert.AreEqual("A♠ K♣ Q♥ J♦ 10♠", hand.ToString());
        }

        [TestMethod]
        public void ToStringWithSameCard()
        {
            var hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            Assert.AreEqual("A♠ A♠", hand.ToString());
        }
    }
}
