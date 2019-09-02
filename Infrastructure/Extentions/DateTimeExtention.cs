using System;

namespace Infrastructure.Extentions
{
    public static class DateTimeExtention
    {
        public static DateTime TimeStampToDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }
    }
}