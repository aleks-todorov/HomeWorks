using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentRepresentation
{
    class Application
    {
        static void Main(string[] args)
        {
            var studentOne = new Student("Ivan", "Georgiev", "Dimitrov", "0123456789", "Sofia,Some str,15", "35988888888", "someEamil@mailsrv.com", 4, Specialties.Chemistry, Universities.SofiaUniversity, Faculties.Science);
            var studentTwo = new Student("George", "Dimitrov", "Dimitrov", "9876543210", "Sofia,Some str,25", "077777777", "someOtherEmail@mailsrv.com", 7, Specialties.Engineering, Universities.TechnicalUniversity, Faculties.MechanicallEngineering);

            //Showing overwritten ToString()
            Console.WriteLine(studentOne.ToString());

            //Task 2: Test
            var studentThree = studentOne.Clone();
            Console.WriteLine(studentThree.ToString());

            //Task 3: Test will return 0 which shows that they are same
            Console.WriteLine(studentOne.CompareTo(studentThree));
        }
    }
}
