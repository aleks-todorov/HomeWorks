using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.CommonClasses
{
    public class GSMCallHistoryTest
    {
        private GSM phone;

        public GSM Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public GSMCallHistoryTest()
        {
            this.phone = new GSM("Something", "Nokia", 1150, "John", new Battery("2343DCD", 50, 20, BatteryType.LiIon), new Display(15.4, 1000000000));
        }

        public void AddCalls()
        {
            this.phone.CallHistory.Add(new Call("12/02/2013", "18:43:43", 35988543524234, 58));
            this.phone.CallHistory.Add(new Call("12/02/2013", "13:32:43", 35988543534324, 112));
            this.phone.CallHistory.Add(new Call("12/02/2013", "11:12:43", 35988122344324, 432));
            this.phone.CallHistory.Add(new Call("12/02/2013", "05:41:43", 35988122344234, 15));
        }

        public void ShowCalls()
        {
            foreach (var call in this.phone.CallHistory)
            {
                call.ToString();
                Console.WriteLine();
            }
        }

        public void CalculateTotalPrice()
        {
            Console.WriteLine("Total Price: {0:F2} лв.", this.phone.CalculatePrice(0.37m));
        }

        public void RemoveLongestCall()
        {
            this.phone.CallHistory = this.phone.CallHistory.OrderByDescending(t => t.Duration).ToList();
            this.phone.CallHistory.RemoveAt(0);
            CalculateTotalPrice();
        }

        public void ClearCallHistory()
        {
            Console.WriteLine();
            this.phone.CallHistory.Clear();
            Console.WriteLine("Total calls in CallHistory: {0}", this.phone.CallHistory.Count());
            ShowCalls();
        }
    }
}
