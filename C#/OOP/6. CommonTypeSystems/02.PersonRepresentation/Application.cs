using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonRepresentation
{
    class Application
    {
        static void Main(string[] args)
        {
            var personOne = new Person("Gosho", 10);
            var personTwo = new Person("Pesho");

            Console.WriteLine(personOne.ToString());
            Console.WriteLine(personTwo.ToString());
        }
    }
}
