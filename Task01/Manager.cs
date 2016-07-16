using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Manager
    {
        /// <summary>
        /// Method alert time work is end. 
        /// </summary>
        private void SayGoodBey(Object sender, ClockEventArgs clock) =>
            Console.WriteLine($"Manager:\nMy Work is end!  I worked {clock.Time} minutes.  I gonna home.");
        /// <summary>
        /// The method that subscribes to the event notification about the end of work
        /// </summary>
        public void SubscribeToInfo(Clock clock) => clock.EndTimeWork += SayGoodBey;

        /// <summary>
        /// The method that unsubscribes to the event notification about the end of work
        /// </summary>
        public void UnSubscribeToInfo(Clock clock) => clock.EndTimeWork -= SayGoodBey;
    }
}
