using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TimerExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Timer Example";

			TimerFunctions timerFunctions = new TimerFunctions();
			int time = 0;
			bool outerLoopContinue = true;

			Console.WriteLine("Set your timer - ");

            // loop to allow the user to enter hours, minutes, seconds multiple times
            // hitting ENTER breaks the loop
            // the time entered on each loop is accumulated.
            while (outerLoopContinue)
            {
                int inputTimeInterval = 0;
                int inputTimeIncrement = 0;

                Console.WriteLine("\r\n1 - enter hours");
                Console.WriteLine("2 - enter minutes");
                Console.WriteLine("3 - enter seconds");
                string input = Console.ReadLine();

                if (input != "")
                {
                    bool innerLoopContinue = true;
                    while (innerLoopContinue)
                    {
                        inputTimeInterval = timerFunctions.ValidateTimeInterval(input);
                        if (inputTimeInterval > 0)
                        {
                            if (inputTimeInterval == 1)
                            {
                                Console.WriteLine($"\r\nEnter the hours");
                            }
                            else if (inputTimeInterval == 2)
                            {
                                Console.WriteLine($"\r\nEnter the minutes");
                            }
                            else
                            {
                                Console.WriteLine($"\r\nEnter the seconds");
                            }

                            input = Console.ReadLine();
                            inputTimeIncrement = timerFunctions.ValidateTimeIncrement(input);
                            if (inputTimeIncrement > -1)
                            {
                                //  accummulate the time
                                time += timerFunctions.ConvertToSeconds(inputTimeInterval, inputTimeIncrement);
                                innerLoopContinue = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid time interval = " + input);
                            Console.WriteLine("\r\n1 - enter hours");
                            Console.WriteLine("2 - enter minutes");
                            Console.WriteLine("3 - enter seconds");
                            input = Console.ReadLine();
                        }
                    }
                }
                else
                {
                    outerLoopContinue = false;
                }
            }


			Console.WriteLine($"Your timer interval is {time.ToString("###,###,###")} seconds -- {timerFunctions.ConvertSecondsToHoursMinutesSeconds(time)}");

            /*
			timerFunctions.SetTimerInterval(time);

			if (timerFunctions.TimerInterval > 0)
			{
				timerFunctions.myTimer.Elapsed += MyTimer_Elapsed;
				timerFunctions.StartTimer();
			}
            */
			Console.ReadLine();
		}

		//  raised event
		private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			Console.WriteLine($"Times up! {e.SignalTime} {sender.ToString()}");
		}
	}
}
