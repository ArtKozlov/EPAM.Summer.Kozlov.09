using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace Task01.TestsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            var worker = new Worker();
            var manager = new Manager();
            worker.SubscribeToInfo(clock);
            manager.SubscribeToInfo(clock);
            clock.SetTimeWorkEmployees(0);
            worker.UnSubscribeToInfo(clock);
            clock.SetTimeWorkEmployees(1);
            Console.ReadKey();
        }
    }
}
