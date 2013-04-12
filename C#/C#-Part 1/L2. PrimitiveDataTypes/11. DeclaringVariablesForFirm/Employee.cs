using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DeclaringVariablesForFirm
{
    class Employee
    {
        private string firstName;
        private string lastName;
        private int age;
        private long idNumber;
        private string gender;
        private int employeeID;

        // Property Declaration
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public long IDNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        //Constructors Declaration

        public Employee(string firstName, string lastName,int age, long idNumber, string gender, int employeeID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.employeeID = employeeID;
            this.age = age;
            this.idNumber = idNumber;
        }

        //Declaring a Method to print the newly created employee

        public void PrintEmployeeInformatio()
        {
            Console.WriteLine("Employee first name is: " + this.firstName);
            Console.WriteLine("Employee last name is: " + this.lastName);
            Console.WriteLine("Employee age is: " + this.age);
            Console.WriteLine("Employee gender is " + gender);
            Console.WriteLine("Employee ID Number is: " + this.idNumber);
            Console.WriteLine("Employee personal ID is: " + employeeID);
            Console.WriteLine();
        }
    }
}
