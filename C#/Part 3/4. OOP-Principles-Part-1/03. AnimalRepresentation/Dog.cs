using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    class Dog : Animal
    {
        public Dog(int age, string name, bool isMale)
            : base(age, name, isMale)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine(this.Name + " said: Woffff-woff");
        }

    }
}
