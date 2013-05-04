using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CreatingHuman
{
    public enum Gender { megaHuman, hotChick };

    public class Human
    {
        public Gender Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Human(int age)
        {
            this.Age = age;
            if (Age % 2 == 0)
            {
                this.Name = "Superman";
                this.Sex = Gender.megaHuman;
            }
            else
            {
                this.Name = "The Chick";
                this.Sex = Gender.hotChick;
            }
        }

    }
}
