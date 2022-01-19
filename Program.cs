using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class TimeEventArgs : EventArgs
    {
        public readonly int Second;
        public readonly int Minute;
        public readonly int Hour;
        public TimeEventArgs(int s, int m, int h)
        {
            Hour = s;
            Minute = m;
            Second = h;
        }
    }
    public class Clock
    {
        public delegate void ClockHandler(object clock, TimeEventArgs e);
        public event ClockHandler OnceSecondChange ;
        public void Run()
        {
            do
            {
                Thread.Sleep(1000);
                DateTime dt = DateTime.Now;
                OnceSecondChange?.Invoke(this, new TimeEventArgs(dt.Hour, dt.Minute, dt.Second));
            }while (true);
        }
    }
    public class Clock1
    {
        public void subcrib (Clock clock1)
        {
            clock1.OnceSecondChange += new Clock.ClockHandler(ShowClock1);
        }
        public void ShowClock1(object clock, TimeEventArgs e)
        {
            Console.WriteLine("Clock 1: Bây giờ là {0} giờ {1} phút {2} giây ", e.Hour, e.Minute, e.Second);
        }
    }
    public class Clock2
    {
        public void subcrib (Clock clock2)
        {
            clock2.OnceSecondChange += new Clock.ClockHandler(ShowClock2);
        }
        public void ShowClock2(object clock, TimeEventArgs e)
        {
            Console.WriteLine("Clock 2: Bây giờ là {0} giờ {1} phút {2} giây ", e.Hour, e.Minute, e.Second);
        }
    }
    public class Program
    {
        public static void Main(string[] arg)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Clock clock = new Clock();
            Clock1 clock1 = new Clock1();
            Clock2 clock2 = new Clock2();
            clock1.subcrib(clock);
            clock2.subcrib(clock);
            clock.Run();
        }
    }
}





