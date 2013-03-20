using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    class TomCat : Cat
    {
        public TomCat(int age, string name, bool isMale)
            : base(age, name, isMale)
        {
            try
            {
                if (isMale == false)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.IsMale = isMale;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("TomCats can only be male!");
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine(this.Name + " said: Whateva tomcats say");
        }
    }
}
