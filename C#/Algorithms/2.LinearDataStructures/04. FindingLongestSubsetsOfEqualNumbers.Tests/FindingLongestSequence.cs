using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04.FindingLongestSubsequenceOfEqualNumbers;

namespace _04.FindingLongestSubsetsOfEqualNumbers.Tests
{
    [TestClass]
    public class FindingLongestSequence
    {
        [TestMethod]
        public void FindLongestSequenceOfSingeElements()
        {
            var numbers = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var longestSequence = LongestSequence.FindLongestSequence(numbers);
            Assert.AreEqual(longestSequence.Count, numbers.Count);
        }

        [TestMethod]
        public void FindLongestSequenceOfTwoElements()
        {
            var numbers = new List<int> { 1, 2, 1, 2, 1, 1, 2, 2, 2 };
            var longestSequence = LongestSequence.FindLongestSequence(numbers);
            Assert.AreEqual(longestSequence.Count, 5);
            Assert.AreEqual(longestSequence[0], 2);
        }

        [TestMethod]
        public void FindLongestSequenceOfMultipleNumbers()
        {
            var numbers = new List<int> { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            var longestSequence = LongestSequence.FindLongestSequence(numbers);
            Assert.AreEqual(longestSequence.Count, 4);
            Assert.AreEqual(longestSequence[0], 4);
        }

        [TestMethod]
        public void FindLongestSequenceOfDifferentNumbers()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var longestSequence = LongestSequence.FindLongestSequence(numbers);
            Assert.AreEqual(longestSequence.Count, 1);
            Assert.AreEqual(longestSequence[0], 1);
        }
    }
}
