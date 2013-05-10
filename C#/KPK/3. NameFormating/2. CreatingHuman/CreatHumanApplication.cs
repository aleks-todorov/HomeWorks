using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CreatingHuman
{
    class MainClass
    {
        public static void Main()
        {
            var person = new Human(25);
            Console.WriteLine("Person's Name: {0}, Person's Gender: {1}", person.Name, person.Sex);
        }
    }

}
