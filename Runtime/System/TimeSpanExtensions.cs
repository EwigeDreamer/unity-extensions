using System;

namespace ED.Extensions.System
{
    public static class TimeSpanExtensions
    {
        public static long ToSecondsLong(this TimeSpan span)
        {
            return span.Ticks / TimeSpan.TicksPerSecond;
        }
    }
}