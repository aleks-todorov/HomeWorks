using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook
{
    public class PhonebookList : IComparable<PhonebookList>
    {
        private string contactName;
        private string contactNameToLower;

        public string Name
        {
            get
            {
                return this.contactName;
            }
            set
            {
                this.contactName = value;
                this.contactNameToLower = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> Strings;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            sb.Append(this.Name);
            bool isFirstPhone = true;

            foreach (var phone in this.Strings)
            {
                if (isFirstPhone)
                {
                    sb.Append(": ");
                    isFirstPhone = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');
            return sb.ToString();
        }

        public int CompareTo(PhonebookList other)
        {
            return this.contactNameToLower.CompareTo(other.contactNameToLower);
        }
    }
}
