using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomException
{
    class CustomException
    {
        static void Main(string[] args)
        {

            int numberOutOfRange = 12343;

            //Throws int Exception
            if (numberOutOfRange < 1 || numberOutOfRange > 100)
            {
                throw new InvalidRangeException<int>("Please enter valid range", 1, 100);
            }

            //Throws DateTime Exception
            DateTime dateOutOfRange = new DateTime(2031, 03, 19);

            if (dateOutOfRange.Year < 1980 || dateOutOfRange.Year > 2013)
            {
                throw new InvalidRangeException<DateTime>("Please enter valid range", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }

        }
    }
}
