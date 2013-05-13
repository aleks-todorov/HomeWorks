using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CookingApp
{
    public class CookingApp
    {
        public void Cook()
        {
            Bowl bowl = GetBowl();
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Peel(potato);
            Peel(carrot);
            Cut(potato);
            Cut(carrot);
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        public Bowl GetBowl()
        {
            //... 
        }

        public void Cut(Vegetable potato)
        {
            //...
        }

        public Carrot GetCarrot()
        {
            //...
        }

        private Potato GetPotato()
        {
            //...
        }
    }
}

