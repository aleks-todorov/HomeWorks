using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DeclaringVariablesForFirm
{
    class DeclaringVariablesForFirm
    {
        static void Main()
        {
          //A marketing firm wants to keep record of its employees. 
          //Each record would have the following characteristics – first name, family name, age, 
          //gender (m or f), ID number, unique employee number (27560000 to 27569999). 
          //Declare the variables needed to keep the information for a single employee using 
          //appropriate data types and descriptive names.


            int totalEmployeeNumbers = 27569999 - 27560000;
            Console.WriteLine("Please specify how many employes you want to create ?");
            int employeesToCreate = int.Parse(Console.ReadLine());
            if (employeesToCreate <= totalEmployeeNumbers)
            {
                int startingEmployeeID = 27560000;
                for (int i = 0; i < employeesToCreate; i++)
                {
                    Console.WriteLine("Please enter employee first name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please enter employee last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Please enter employee age:");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter employee ID Number:");
                    long idNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter employee gender: ");
                    string gender = Console.ReadLine();
                    if (gender == "Male" | gender == "Female")
                    {
                        int employeeID = startingEmployeeID + i;
                        Employee newEmployee = new Employee(firstName, lastName,age,idNumber, gender, employeeID);
                        newEmployee.PrintEmployeeInformatio();
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid Gender.It should be Male of Female");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("The maximum employees that can be creted are: {0}", totalEmployeeNumbers);
                Main();
            }
        }
    }
}

