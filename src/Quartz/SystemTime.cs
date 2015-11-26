using System;

namespace Quartz
{
    /// <summary>
    /// A time source for Quartz.NET that returns the current time.
    /// Original idea by Ayende Rahien:
    /// http://ayende.com/Blog/archive/2008/07/07/Dealing-with-time-in-tests.aspx
    /// </summary>
    public static class SystemTime
    {
        private static object locker = new object();
        private static TimeSpan timeDifference = new TimeSpan(0, 0, 0);

        /// <summary>
        /// –азница во времени
        /// –азница между временем текущей системы и временем поставщика точного времени
        /// </summary>
        public static TimeSpan TimeDifference
        {
            get
            {
                return timeDifference;
            }
        }

        /// <summary>
        /// Return current UTC time via <see cref="Func&lt;T&gt;" />. Allows easier unit testing.
        /// </summary>
        public static Func<DateTimeOffset> UtcNow = () => DateTimeOffset.UtcNow + SystemTime.TimeDifference;

        /// <summary>
        /// Return current time in current time zone via <see cref="Func&lt;T&gt;" />. Allows easier unit testing.
        /// </summary>
        public static Func<DateTimeOffset> Now = () => DateTimeOffset.Now + SystemTime.TimeDifference;

        /// <summary>
        /// ћетод установки разницы во времени
        /// ѕримен€етс€ дл€ установки разницы между временем текущей системы и временем поставщика точного времени
        /// </summary>
        /// <param name="timeDiff"></param>
        public static void SetTimeDifference(TimeSpan timeDiff)
        {
            lock (locker)
            {
                timeDifference = timeDiff;
            }
        }
    }
}