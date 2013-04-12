using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Task 7: 
//Using delegates write a class Timer that can execute certain method at each t seconds.

namespace _07.CreatingTimer
{

    public delegate void SimpleDelegate(DateTime currentTime);

    class UsingDelegates
    {
        static void ShowTime(DateTime currentTime)
        {
            Console.WriteLine("Current Time is: {0:D2}:{1:D2}:{2:D2}", currentTime.Hour, currentTime.Minute, currentTime.Second);
        }

        static void Main(string[] args)
        {
            SimpleDelegate d = new SimpleDelegate(ShowTime);
            ExecuteTimer(d, 1000);

        }

        private static void ExecuteTimer(SimpleDelegate d, int deley)
        {
            while (true)
            {
                DateTime time = DateTime.Now;
                d(time);
                Thread.Sleep(deley);
                Console.Clear();
            }
        }
    }
}
