using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task01
{
    public class Clock
    {

        public event EventHandler<ClockEventArgs> EndTimeWork;

        protected virtual void OnEndTimeWork(object sender, ClockEventArgs e) => EndTimeWork?.Invoke(this, e);

        /// <summary>
        /// Method set time work and send it subscribes.
        /// </summary>
        /// <param name="time">time work</param>
        public void SetTimeWorkEmployees(int time)
        {
            Console.WriteLine("You set time work for employees!");
            Thread.Sleep(time * 60000);
            OnEndTimeWork(this, new ClockEventArgs(time));
        }
    }
}
