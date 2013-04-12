using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.CommonClasses
{
    public class GSM
    {
        private string deviceModel;
        private string manufacturer;
        private int price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S = new GSM("IPhone4S", "Apple", 1150, "John", new Battery("2343DCD", 50, 20, BatteryType.LiIon), new Display(15.4, 1000000000));
        private List<Call> callHistory;

        public string DeviceModel
        {
            get { return deviceModel; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("This field cannot be empty");
                }
                else
                {
                    deviceModel = value;
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("This field cannot be empty");
                }
                else
                {
                    manufacturer = value;
                }
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input");
                }
                else
                {
                    price = value;
                }
            }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }

        public GSM(string deviceModel, string manufacturer)
        {
            this.DeviceModel = deviceModel;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>();
        }

        public GSM(string deviceModel, string manufacturer, int price, string owner, Battery battery, Display display)
        {
            this.DeviceModel = deviceModel;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.battery = battery;
            this.display = display;
            this.CallHistory = new List<Call>();
        }

        public void ToString()
        {
            Console.WriteLine("Device Model: {0}", this.DeviceModel);
            Console.WriteLine("Device Manufactorer: {0}", this.Manufacturer);
            Console.WriteLine("Device Price: {0}", this.Price);
            Console.WriteLine("Device Owner: {0}", this.Owner);
            this.battery.ToString();
            this.display.ToString();
        }

        public void ShowCallerHistory()
        {
            foreach (var call in callHistory)
            {
                call.ToString();
            }
        }

        public decimal CalculatePrice(decimal pricePerMinute)
        {
            decimal timeTalked = 0;
            foreach (var call in callHistory)
            {
                timeTalked += call.Duration;
            }

            decimal totalMoney = (pricePerMinute / 60) * timeTalked;
            return totalMoney;
        }
    }
}
