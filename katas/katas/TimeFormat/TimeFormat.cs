using System;

// Human Readable Time
namespace katas.TimeFormat
{
    public static class TimeFormat
    {
        public static string GetReadableTime(int seconds)
        {
            var time = new TimeSpan(0, 0, 0, seconds);
            var hours = (time.Hours + time.Days * 24).ToString().PadLeft(2, '0');
            var minutes = time.Minutes.ToString().PadLeft(2, '0');
            var secs = time.Seconds.ToString().PadLeft(2, '0');
            return $"{hours}:{minutes}:{secs}";
        }
    }
}