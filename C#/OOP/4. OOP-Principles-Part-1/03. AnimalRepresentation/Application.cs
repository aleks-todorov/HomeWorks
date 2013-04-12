using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalRepresentation
{
    class Application
    {
        static void Main(string[] args)
        {
            //Dog sharo = new Dog(5, "Sharo", true);
            //sharo.MakeSound();
            //Kitten kitty = new Kitten(5, "Puss", true);
            //TomCat tom = new TomCat(5, "Tom", true);
            //tom.MakeSound();
            //Frog frogy = new Frog(2, "Froggy", true);
            //frogy.MakeSound();

            Animal[] animals = new Animal[4];
            animals[0] = new Dog(3, "Sharo", true);
            animals[1] = new Kitten(5, "Puss", false);
            animals[2] = new TomCat(5, "Tom", true);
            animals[3] = new Frog(2, "Froggy", true);

            foreach (var animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}
