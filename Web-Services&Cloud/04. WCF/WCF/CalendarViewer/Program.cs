using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarViewer.Viewer;

namespace CalendarViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            //In order to visualize the day in cyrilic, Console Font must be changed to Consolas. 
            Console.OutputEncoding = Encoding.UTF8;
            var calendar = new CalendarViewerClient();
            var result = calendar.GetData(DateTime.Now);
            Console.WriteLine(result);

        }
    }
}
