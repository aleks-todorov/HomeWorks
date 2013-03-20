using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    abstract class Cat : Animal
    {
        public Cat(int age, string name, bool isMale)
            : base(age, name, isMale)
        {
        }
    }
}
