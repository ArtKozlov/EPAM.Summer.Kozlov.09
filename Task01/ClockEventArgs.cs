using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public sealed class ClockEventArgs : EventArgs
    {
        private int _time;
        public int Time
        {
            private set
            {
                if (_time < 0)
                    throw new ArgumentException();
                _time = value;
            }
            get { return _time; }
        }

        public ClockEventArgs(int time)
        {
            Time = time;
        }
    }
}
