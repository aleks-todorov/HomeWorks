using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.CommonClasses
{
    public class Battery
    {
        private string batteryModel;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType;

        public string BatteryModel
        {
            get { return batteryModel; }
            set { batteryModel = value; }
        }

        public int HoursIdle
        {
            get { return hoursIdle; }
            set
            {

                if (value < 0)
                {
                    throw new ArgumentException("Invalid HoursIdle value");
                }
                else
                {
                    hoursIdle = value;
                }
            }
        }

        public int HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid HoursTalk value");
                }
                else
                {
                    hoursTalk = value;
                }
            }
        }

        public BatteryType BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        public Battery(string batteryModel, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.BatteryModel = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public void ToString()
        {
            Console.WriteLine("Battery Model: {0}", this.BatteryModel);
            Console.WriteLine("Battery HoursIdle: {0}", this.HoursIdle);
            Console.WriteLine("Battery HoursTalk: {0}", this.HoursTalk);
            Console.WriteLine("Battery Type: {0}", this.BatteryType);
        }
    }
}
