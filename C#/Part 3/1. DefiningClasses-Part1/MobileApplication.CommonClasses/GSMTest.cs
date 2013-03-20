using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.CommonClasses
{
    public class GSMTest
    {
        private GSM[] phones = {
       new GSM("Something", "Nokia", 1150, "John", new Battery("2343DCD", 50, 20, BatteryType.LiIon), new Display(15.4, 1000000000)),
       new GSM("SomethingElse", "Samsung", 500, "Peter", new Battery("34rfD", 70, 30, BatteryType.NiCd), new Display(8.6, 54)),
       GSM.IPhone4S
                       };

        public void PrintTests()
        {
            for (int i = 0; i < phones.Length; i++)
            {
                this.phones[i].ToString();
                Console.WriteLine();
            }
        }
    }
}
