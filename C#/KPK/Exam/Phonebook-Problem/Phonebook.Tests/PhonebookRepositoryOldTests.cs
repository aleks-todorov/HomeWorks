using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace Phonebook.Tests
{
    [TestClass]
    public class PhonebookRepositoryOldTests
    {
        [TestMethod]
        public void TestMethodAddPhoneWithSingleEntry()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Beta", new string[] { "+359444555666" });
            var people = phoneRepo.ListEntries(0, 1);
            Assert.AreEqual(people.Count(), 1);
        }

        [TestMethod]
        public void TestMethodAddPhoneWithTwoEntries()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Gamma", new string[] { "+359777888999" });
            phoneRepo.AddPhone("Beta", new string[] { "+359444555666" });
            var people = phoneRepo.ListEntries(0, 2);
            Assert.AreEqual(people.Count(), 2);
        }

        [TestMethod]
        public void TestMethodAddPhoneWithMultipleEntries()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Gamma", new string[] { "+359777888999" });
            phoneRepo.AddPhone("Beta", new string[] { "+359444545666" });
            phoneRepo.AddPhone("Alfa", new string[] { "+359443455666" });
            phoneRepo.AddPhone("Omega", new string[] { "+359444556789" });
            phoneRepo.AddPhone("Delta", new string[] { "+357665555666" });
            phoneRepo.AddPhone("Epsilon", new string[] { "+359666666666" });
            var people = phoneRepo.ListEntries(0, 6);
            Assert.AreEqual(people.Count(), 6);
        }

        [TestMethod]
        public void TestMethodAddPhoneWith1000Entries()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            for (int i = 0; i < 1000; i++)
            {
                phoneRepo.AddPhone("Contact" + i, new string[] { "+359777888999" });
            }
            var people = phoneRepo.ListEntries(0, 1000);
            Assert.AreEqual(people.Count(), 1000);
        }

        [TestMethod]
        public void TestMethodAddPhoneOfUserWithSmallAndBigStartingLetter()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Beta", new string[] { "+359444555666" });
            phoneRepo.AddPhone("beta", new string[] { "+359000000000" });
            var people = phoneRepo.ListEntries(0, 1);
            var expected = "[Beta: +359000000000, +359444555666]";
            Assert.AreEqual(people[0].ToString(), expected);
        }

        [TestMethod]
        public void TestMethodChangePhoneOfSingleContact()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Alfa", new string[] { "+359443455666" });
            var numbersChanged = phoneRepo.ChangePhone("+359443455666", "+359888888888");
            var contactList = phoneRepo.ListEntries(0, 1);
            var expected = "[Alfa: +359888888888]";
            Assert.AreEqual(numbersChanged, 1);
            Assert.AreEqual(contactList[0].ToString(), expected);
        }

        [TestMethod]
        public void TestMethodChangePhoneOfSingleContactMultipleTimes()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Alfa", new string[] { "+359443455666" });
            phoneRepo.ChangePhone("+359443455666", "+359888888888");
            phoneRepo.ChangePhone("+359888888888", "+359777777777");
            phoneRepo.ChangePhone("+359777777777", "+359666666666");
            phoneRepo.ChangePhone("+359666666666", "+359555555555");
            var contactList = phoneRepo.ListEntries(0, 1);
            var expected = "[Alfa: +359555555555]";
            Assert.AreEqual(contactList[0].ToString(), expected);
        }

        [TestMethod]
        public void TestMethodChangePhoneOfMultipleContacts()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Alfa", new string[] { "+359443455666" });
            phoneRepo.AddPhone("Beta", new string[] { "+359443455666" });
            phoneRepo.AddPhone("Gama", new string[] { "+359443455666" });
            var numberOfPhoneChanged = phoneRepo.ChangePhone("+359443455666", "+359888888888");

            var contactList = phoneRepo.ListEntries(0, 3);
            var output = new StringBuilder();
            for (int i = 0; i < contactList.Count(); i++)
            {
                output.AppendLine(contactList[i].ToString());
            }
            var expected = "[Alfa: +359888888888]\r\n" +
                "[Beta: +359888888888]\r\n" +
                "[Gama: +359888888888]\r\n";
            Assert.AreEqual(contactList.Count(), 3);
            Assert.AreEqual(output.ToString(), expected);
        }

        [TestMethod]
        public void TestMethodChangePhoneOfGIvenContacts()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Alfa", new string[] { "+359443455666" });
            phoneRepo.AddPhone("Beta", new string[] { "+359443455666" });
            phoneRepo.AddPhone("Gama", new string[] { "+359443455666" });
            phoneRepo.AddPhone("Omega", new string[] { "+359444556789" });
            phoneRepo.AddPhone("Delta", new string[] { "+357665555666" });
            phoneRepo.AddPhone("Epsilon", new string[] { "+359443455666" });
            phoneRepo.ChangePhone("+359443455666", "+359888888888");
            var contactList = phoneRepo.ListEntries(0, 6);
            var output = new StringBuilder();
            for (int i = 0; i < contactList.Count(); i++)
            {
                output.AppendLine(contactList[i].ToString());
            }
            var expected = "[Alfa: +359888888888]\r\n" +
                "[Beta: +359888888888]\r\n" +
                "[Delta: +357665555666]\r\n" +
                "[Epsilon: +359888888888]\r\n" +
                "[Gama: +359888888888]\r\n" +
                "[Omega: +359444556789]\r\n";
            Assert.AreEqual(output.ToString(), expected);
        }

        [TestMethod]
        public void TestMethodListEntriesOfSingleUser()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Beta", new string[] { "+359444555666" });
            var people = phoneRepo.ListEntries(0, 1);
            var expected = "[Beta: +359444555666]";
            Assert.AreEqual(people[0].ToString(), expected);
        }

        [TestMethod]
        public void TestMethodListEntriesOfMultipleEntries()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Beta", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Delta", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Alfa", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Omega", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Epsilon", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Gama", new string[] { "+35900000000" });
            var contactList = phoneRepo.ListEntries(0, 6);
            var output = new StringBuilder();
            for (int i = 0; i < contactList.Count(); i++)
            {
                output.AppendLine(contactList[i].ToString());
            }

            var expected = "[Alfa: +35900000000]\r\n" +
                "[Beta: +35900000000]\r\n" +
                "[Delta: +35900000000]\r\n" +
                "[Epsilon: +35900000000]\r\n" +
                "[Gama: +35900000000]\r\n" +
                "[Omega: +35900000000]\r\n";
            Assert.AreEqual(output.ToString(), expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethodListEntriesWithInvalidFirstParameter()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Beta", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Delta", new string[] { "+35900000000" });
            var contactList = phoneRepo.ListEntries(0, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethodListEntriesWithInvalidSecondParameter()
        {
            var phoneRepo = new PhonebookRepositoryOld();
            phoneRepo.AddPhone("Beta", new string[] { "+35900000000" });
            phoneRepo.AddPhone("Delta", new string[] { "+35900000000" });
            var contactList = phoneRepo.ListEntries(5, 6);
        }
    }
}
