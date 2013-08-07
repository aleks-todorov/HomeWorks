using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook
{
    public class Application
    {
        //For the main method I have used the new repository. For the unit testing I have used both;
        private static IPhonebookRepository data = new PhonebookRepositoryNew();
        private static StringBuilder input = new StringBuilder();

        public static void Main()
        {
            ReadCommand();

            Console.Write(input);
        }

        private static void ReadCommand()
        {
            while (true)
            {
                string inputData = Console.ReadLine();
                if (inputData == "End" || inputData == null)
                {
                    break;
                }

                int indexOfInputContentStart = CheckForStartOfTheContent(inputData);
                string command = inputData.Substring(0, indexOfInputContentStart);
                var startIndex = indexOfInputContentStart + 1;
                var endIndex = inputData.Length - indexOfInputContentStart - 2;
                string content = inputData.Substring(startIndex, endIndex);
                string[] contentInformation = content.Split(',');

                ProcessInputCommand(command, contentInformation);
            }
        }

        private static int CheckForStartOfTheContent(string inputData)
        {
            int indexOfInputContentStart = inputData.IndexOf('(');
            if (indexOfInputContentStart == -1)
            {
                throw new ArgumentException("Provided command was not valid. Please check and try again! ");
            }
            return indexOfInputContentStart;
        }

        private static void ProcessInputCommand(string command, string[] contentInformation)
        {
            for (int j = 0; j < contentInformation.Length; j++)
            {
                contentInformation[j] = contentInformation[j].Trim();
            }

            if (contentInformation.Length < 2)
            {
                throw new ArgumentException("Provided command was not valid. Please check and try again! ");
            }

            if (command == "AddPhone")
            {
                ProcessCommand("AddPhone", contentInformation);
            }

            else if (command == "ChangePhone")
            {
                ProcessCommand("ChangePhone", contentInformation);
            }

            else if (command == "List")
            {
                ProcessCommand("List", contentInformation);
            }

            else
            {
                throw new InvalidOperationException("Invalid command. Please check and try again");
            }
        }

        private static void ProcessCommand(string command, string[] commandContent)
        {
            if (command == "AddPhone") // first command
            {
                ProcessCommandAddPhone(commandContent);
            }

            else if (command == "ChangePhone")
            {
                ProcessCommandChangePhone(commandContent);
            }

            else if (command == "List")
                ProcessCommandList(commandContent);
        }

        private static void ProcessCommandList(string[] commandContent)
        {
            try
            {
                var startIndex = int.Parse(commandContent[0]);
                var endIndex = int.Parse(commandContent[1]);
                IEnumerable<PhonebookList> contactsList = data.ListEntries(startIndex, endIndex);

                foreach (var contact in contactsList)
                {
                    Print(contact.ToString());
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                Print("Invalid range");
            }
        }

        private static void ProcessCommandChangePhone(string[] commandContent)
        {
            var firstConvertedNumber = ParsePhone(commandContent[0]);
            var secondConvertedNumber = ParsePhone(commandContent[1]);
            var numbersOfChangedPhones = data.ChangePhone(firstConvertedNumber, secondConvertedNumber);
            Print(numbersOfChangedPhones + " numbers changed");
        }

        private static void ProcessCommandAddPhone(string[] commandContent)
        {
            string name = commandContent[0];
            var additionalPhoneNumbers = commandContent.Skip(1).ToList();
            for (int i = 0; i < additionalPhoneNumbers.Count; i++)
            {
                additionalPhoneNumbers[i] = ParsePhone(additionalPhoneNumbers[i]);
            }

            bool isNewPhone = data.AddPhone(name, additionalPhoneNumbers);

            if (isNewPhone)
            {
                Print("Phone entry created.");
            }
            else
            {
                Print("Phone entry merged");
            }
        }

        private static string ParsePhone(string phoneNumber)
        {
            string code = "+359";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= input.Length; i++)
            {
                sb.Clear();

                foreach (char ch in phoneNumber)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }
                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1); sb[0] = '+';
                }
                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, code);
                }
            }
            return sb.ToString();
        }

        private static void Print(string text)
        {
            input.AppendLine(text);
        }
    }
}
