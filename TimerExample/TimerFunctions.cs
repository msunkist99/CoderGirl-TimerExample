using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerExample
{
	public class TimerFunctions
	{
		public Timer myTimer = new Timer();
		public int TimerInterval { get; set ; }

		public void StartTimer()
		{
			myTimer.Start();
		}

		public void StopTimer()
		{
			myTimer.Stop();
		}

		//  valid intervals are
		//   1 hours
		//   2 minutes
		//   3 seconds
		public void SetTimerInterval(int interval)
		{
			TimerInterval = 0;

			try
			{
				TimerInterval = interval;
			}
			catch(Exception e)
			{
				Console.WriteLine($"There is a problem with your timer interval value - {interval}");
				Console.WriteLine(e.Message);
			}
 
			try
			{
				myTimer.Interval = TimerInterval * 1000;
			}
			catch(Exception e)
			{
				Console.WriteLine($"There is a problem with your timer interval value {interval}");
				Console.WriteLine(e.Message);
			}
		}

		//  hours and minute time increment must be converted from hours/minutes to seconds
		public int ConvertToSeconds(int interval, int increment)
		{
			if (interval == 1)      // hours
			{
				increment = increment * 60 * 60;
			}
			else if (interval == 2)  // minutes
			{
				increment = increment * 60;
			}
			else                   // seconds
			{
			}

			return increment;
		}

		//  time interval must be an integer value > 0
		public int ValidateTimeInterval(string timeInterval)
		{
			int inputTimeInterval = 0;

			try
			{
				inputTimeInterval = Convert.ToInt16(timeInterval);

				if ((inputTimeInterval < 1) || (inputTimeInterval > 3))
				{
					return -1;
				}
				else
				{
					return inputTimeInterval;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine($"Your timer input was invalid - {timeInterval}");
				return -1;
			}
		}

		public int ValidateTimeIncrement(string timeIncrement)
		{
			try
			{
				return Convert.ToInt16(timeIncrement);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine($"Your time increment was invalid - {timeIncrement}");
				return -1;
			}

		}

		public string ConvertSecondsToHoursMinutesSeconds(int seconds)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

			return string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
				timeSpan.Hours,
				timeSpan.Minutes,
				timeSpan.Seconds,
				timeSpan.Milliseconds);
		}
	}
}
