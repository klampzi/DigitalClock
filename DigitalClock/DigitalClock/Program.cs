using System;
using System.Threading;

namespace DigitalClock
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockDisplay clock;
            clock = new ClockDisplay();

            while (true)
            {
                clock.TimeTick();
            }
        }
    }
    
    public class ClockDisplay
    {
        NumberDisplay hours;
        NumberDisplay minutes;
        NumberDisplay seconds;

        string displayString;

        public ClockDisplay()
        {
            hours = new NumberDisplay(24);
            minutes = new NumberDisplay(60);
            seconds = new NumberDisplay(60);
            UpdateDisplay();
        }



        public void UpdateDisplay()
        {
            displayString = hours.GetDisplayValue() + ":" + minutes.GetDisplayValue() + ":" + seconds.GetDisplayValue(); ;
            Console.WriteLine(displayString);
        }

        public void TimeTick()
        {
            Thread.Sleep(1000);
            seconds.increment();
            if(seconds.GetValue() == 0)
            {
                minutes.increment();
                if (minutes.GetValue() == 0)
                {
                    hours.increment();
                }
            }

            UpdateDisplay();

            
        }
    }


    class NumberDisplay
    {
        private int limit;
        private int value;

        public NumberDisplay(int rollOverLimit)
        {
            limit = rollOverLimit;
            value = 0;
        }

        public void increment()
        {
            value++;
            value = value % limit;
        }

        public string GetDisplayValue()
        {
            if(value < 10)
            {
                return "0" + value;
            }
            else
            {
                return value.ToString();
            }
        }

        public void SetValue(int replacementValue)
        {
            if(replacementValue >= 0 && replacementValue < limit)
            {
                value = replacementValue;
            }
        }

        public int GetValue()
        {
            return value;
        }
    }
}
