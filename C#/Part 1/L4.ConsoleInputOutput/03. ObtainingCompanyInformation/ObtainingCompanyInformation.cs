using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ObtainingCompanyInformation
{
    class ObtainingCompanyInformation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Company Name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Please enter Company Address:");
            string companyAddress = Console.ReadLine();
            Console.WriteLine("Please enter Company Phone Number:");
            int companyPhoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Company Fax Number:");
            int companyFaxNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Company WebSite:");
            string companyWebSite = Console.ReadLine();
            Console.WriteLine("Please enter Company Manager:");
            string companyManager = Console.ReadLine();
            Console.WriteLine("Please enter {0} First Name:", companyManager);
            string managerFirstName = Console.ReadLine();
            Console.WriteLine("Please enter {0} Last Name:", companyManager);
            string managerLastName = Console.ReadLine();
            Console.WriteLine("Please enter {0} Age:", companyManager);
            int managerAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter {0} Phone Number:", companyManager);
            int managerPhoneNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Company {0} has address: {1}, company phone: {2}, fax number: {3}, company website: {4} and Manager: {5} ", companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite, companyManager);
            Console.WriteLine("Manager has First Name: {0}, Last Name: {1}, age: {2} and phone Number: {3}", managerFirstName, managerLastName, managerAge, managerPhoneNumber);
        }
    }
}
