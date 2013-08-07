using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Phonebook
{
    /// <summary>
    /// Class providing functionality for working with Phone
    /// </summary>
    public class PhonebookRepositoryOld : IPhonebookRepository
    {
        /// <summary>
        /// Phonebook sorted by Functionality of Wintellect.PowerCollections;
        /// </summary>
        private OrderedSet<PhonebookList> sortedPhonebookList =
            new OrderedSet<PhonebookList>();

        /// <summary>
        /// Dictionary sorted by Functionality of Wintellect.PowerCollections;
        /// </summary>
        private Dictionary<string, PhonebookList> dictionary =
            new Dictionary<string, PhonebookList>();

        /// <summary>
        /// Multidictionary sorted by Functionality of Wintellect.PowerCollections;
        /// </summary>
        private MultiDictionary<string, PhonebookList> mutliDictionary =
            new MultiDictionary<string, PhonebookList>(false);

        /// <summary>
        ///  Method providing functionality for adding phone contacts into the phone repo
        /// </summary>
        /// <param name="name">name of the contact</param>
        /// <param name="numbersArray">Array of numbers</param>
        /// <returns></returns>
        public bool AddPhone(string name, IEnumerable<string> numbersArray)
        {
            string nameToLower = name.ToLowerInvariant();

            PhonebookList entry;

            bool isNewPhone = !this.dictionary.TryGetValue(nameToLower, out entry);

            if (isNewPhone)
            {
                entry = new PhonebookList();
                entry.Name = name;
                entry.Strings = new SortedSet<string>();
                this.dictionary.Add(nameToLower, entry);
                this.sortedPhonebookList.Add(entry);
            }

            foreach (var phoneNumber in numbersArray)
            {
                this.mutliDictionary.Add(phoneNumber, entry);
            }

            entry.Strings.UnionWith(numbersArray);
            return isNewPhone;
        }

        /// <summary>
        /// Method providing functionality for changing phone of contact
        /// </summary>
        /// <param name="oldPhone">Phone to be changed</param>
        /// <param name="newPhone">New phone</param>
        /// <returns></returns>
        public int ChangePhone(string oldPhone, string newPhone)
        {
            var found = this.mutliDictionary[oldPhone].ToList();

            foreach (var entry in found)
            {
                entry.Strings.Remove(oldPhone);
                this.mutliDictionary.Remove(oldPhone, entry);
                entry.Strings.Add(newPhone);
                this.mutliDictionary.Add(newPhone, entry);
            }

            return found.Count;
        }

        /// <summary>
        /// Method providing funcitonality for listing contacts
        /// </summary>
        /// <param name="startIndex">Start index of the List</param>
        /// <param name="sizeOfPage">Size of the page</param>
        /// <returns></returns>
        public PhonebookList[] ListEntries(int startIndex, int sizeOfPage)
        {
            if (startIndex < 0 || startIndex + sizeOfPage > this.dictionary.Count)
            {
                throw new ArgumentException("Invalid list parameters!");
            }

            PhonebookList[] listOfContacts = new PhonebookList[sizeOfPage];

            for (int index = startIndex; index <= startIndex + sizeOfPage - 1; index++)
            {
                PhonebookList entry = this.sortedPhonebookList[index];
                listOfContacts[index - startIndex] = entry;
            }

            return listOfContacts;
        }
    }
}
