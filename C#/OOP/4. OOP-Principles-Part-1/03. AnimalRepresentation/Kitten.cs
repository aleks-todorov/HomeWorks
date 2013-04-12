﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    class Kitten : Cat
    {
        public Kitten(int age, string name, bool isMale)
            : base(age, name, isMale)
        {
            try
            {
                if (isMale == true)
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
                Console.WriteLine("Kittens can only be female!");
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine(this.Name + " said: Meaooowwww");
        }
    }
}
