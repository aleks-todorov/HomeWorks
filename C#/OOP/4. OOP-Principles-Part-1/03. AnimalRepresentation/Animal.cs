using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    abstract class Animal : ISound
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public string SpecificSound { get; set; }

        protected Animal(int age, string name, bool isMale)
        {
            this.Age = age;
            this.Name = name;
            this.IsMale = isMale;
        }

        public virtual void MakeSound()
        {
        }
    }
}
