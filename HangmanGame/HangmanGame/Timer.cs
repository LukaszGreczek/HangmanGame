using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public  class Timer
    {
        private DateTime startTime;
        private DateTime stopTime;
        private TimeSpan roznica;

        public void StartTimer()
        {
            startTime = DateTime.Now;
        }

        public void EndTimer()
        {
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
        }

        public double DisplayTime()
        {
            return roznica.TotalSeconds;
        }
    }
}
