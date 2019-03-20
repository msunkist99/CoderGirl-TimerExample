using System;
using Xunit;
using TimerExample;

namespace ProgramTest
{
    public class ProgramTest
    {
        public TimerFunctions timerFunctions = new TimerFunctions();

        [Fact]
        public void TimerFunctions_ValidateTimeInterval_Hours()
        {
            Assert.Equal(1, timerFunctions.ValidateTimeInterval("1")) ;
        }

        [Fact]
        public void TimerFunctions_ValidateTimeInterval_Minutes()
        {
            Assert.Equal(2, timerFunctions.ValidateTimeInterval("2"));
        }

        [Fact]
        public void TimerFunctions_ValidateTimeInterval_Seconds()
        {
            Assert.Equal(3, timerFunctions.ValidateTimeInterval("3"));
        }
        [Fact]
        public void TimerFunctions_ValidateTimeInterval_InvalidInput()
        {
            Assert.Equal(-1, timerFunctions.ValidateTimeInterval("5"));
        }
        [Fact]
        public void TimerFunctions_ValidateTimeIncrement_ValidInput()
        {
            Assert.Equal(5, timerFunctions.ValidateTimeIncrement("5"));
        }
        [Fact]
        public void TimerFunctions_ValidateTimeIncrement_InvalidInput()
        {
            Assert.Equal(-1, timerFunctions.ValidateTimeIncrement("A"));
        }
        [Fact]
        public void TimerFunctions_ConvertToSeconds_Hours()
        {
            Assert.Equal(3600, timerFunctions.ConvertToSeconds(1,1));
        }
        [Fact]
        public void TimerFunctions_ConvertToSeconds_Minutes()
        {
            Assert.Equal(60, timerFunctions.ConvertToSeconds(2, 1));
        }
        [Fact]
        public void TimerFunctionsConvertSecondsToHoursMinutesSeconds()
        {
            Assert.Equal("06h:06m:06s:000ms", timerFunctions.ConvertSecondsToHoursMinutesSeconds (21966));
        }
    }
}
