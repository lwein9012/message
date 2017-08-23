using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Message.Common;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CENTANETMESSAGE_{0}_{1}
            Message.ServerManager.ServerHelper.GetQueueImp.Subscribe(string.Format("{0}_{1}", "Test", "Test.Create"), (s, s1) =>
                Console.WriteLine("{0}:{1}", s, s1)
            );

            Console.ReadLine();
        }

        private static string Dt1
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        private static string Dt2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
