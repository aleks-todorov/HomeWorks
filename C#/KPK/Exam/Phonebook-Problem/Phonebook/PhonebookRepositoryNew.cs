using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    /// <summary>
    /// Class providing functionality for working with Phone
    /// </summary>
    public class PhonebookRepositoryNew : IPhonebookRepository
    {
        public List<PhonebookList> listOfPhones = new List<PhonebookList>();

        /// <summary>
        /// Method for adding phone in the repository
        /// </summary>
        /// <param name="name">Contact Name </param>
        /// <param name="phoneNumbers">Array of phone Numbers</param>
        /// <returns></returns>
        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var old =
                from entry in this.listOfPhones
                where entry.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select entry;

            bool oldPhonesFound;

            if (old.Count() == 0)
            {
                PhonebookList newPhoneList = new PhonebookList();
                newPhoneList.Name = name;
                newPhoneList.Strings = new SortedSet<string>();

                foreach (var num in phoneNumbers)
                {
                    newPhoneList.Strings.Add(num);
                }

                this.listOfPhones.Add(newPhoneList);

                oldPhonesFound = true;
            }
            else if (old.Count() == 1)
            {
                PhonebookList phoneContact = old.First();
                foreach (var num in phoneNumbers)
                {
                    phoneContact.Strings.Add(num);
                }

                oldPhonesFound = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + name);
                return false;
            }

            return oldPhonesFound;
        }

        /// <summary>
        /// Method for changing Phone 
        /// </summary>
        /// <param name="oldPhone">Phone to be changed</param>
        /// <param name="newPhone">New phone</param>
        /// <returns></returns>
        public int ChangePhone(string oldPhone, string newPhone)
        {
            var list =
                from e in this.listOfPhones
                where e.Strings.Contains(oldPhone)
                select e;

            int nums = 0;
            foreach (var entry in list)
            {
                entry.Strings.Remove(oldPhone); entry.Strings.Add(newPhone);
                nums++;
            }

            return nums;
        }

        /// <summary>
        /// Method providing functionality for listing of phone contacts
        /// </summary>
        /// <param name="startIndex">start index of the list</param>
        /// <param name="sizeOfPage">Size of the page to be displayed</param>
        /// <returns></returns>
        public PhonebookList[] ListEntries(int startIndex, int sizeOfPage)
        {
            if (startIndex < 0 || startIndex + sizeOfPage > this.listOfPhones.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.listOfPhones.Sort();

            PhonebookList[] phonebookList = new PhonebookList[sizeOfPage];

            for (int index = startIndex; index <= startIndex + sizeOfPage - 1; index++)
            {
                PhonebookList entry = this.listOfPhones[index];
                phonebookList[index - startIndex] = entry;
            }

            return phonebookList;
        }
    }
}
