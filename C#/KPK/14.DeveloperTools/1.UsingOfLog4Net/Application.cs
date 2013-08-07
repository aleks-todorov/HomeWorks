using System;
using log4net;
using log4net.Config;

namespace _1.UsingOfLog4Net
{
    //Imagages for the other tasks can be found in the solution folder. 

    class Application
    {
        private static readonly ILog debug = LogManager.GetLogger("Debug");
        private static readonly ILog exceptions = LogManager.GetLogger("Exceptions");

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            string testMsg = "This is test message!";
            try
            {
                debug.Info("Program starts: ");
                for (int i = 0; i < 100; i++)
                {
                    Console.Write(testMsg[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                exceptions.Error(ex.Message);
            }
        }
    }
}