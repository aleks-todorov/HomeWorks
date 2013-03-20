using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    class Frog : Animal
    {
        public Frog(int age, string name, bool isMale)
            : base(age, name, isMale)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine(this.Name + " said: Quackk - quackk");
        }
    }
}
