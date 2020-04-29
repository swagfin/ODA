using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Libraries
{
    public static class TimeAgo
    {
        public static string Format(DateTime yourDate, bool ExtendPast48Hours = false)
        {
            const int SECOND = 1;
            const int MINUTE_MINIMUM = 30 * SECOND;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            try
            {
                yourDate = yourDate.ToUniversalTime();
                var ts = new TimeSpan(DateTime.UtcNow.Ticks - yourDate.Ticks);
                double delta = Math.Abs(ts.TotalSeconds);

                if (delta < 1 * MINUTE_MINIMUM)
                    return "just now";

                if (delta < 1 * MINUTE)
                    return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

                if (delta < 2 * MINUTE)
                    return "a minute ago";

                if (delta < 45 * MINUTE)
                    return ts.Minutes + " minutes ago";

                if (delta < 90 * MINUTE)
                    return "an hour ago";

                if (delta < 24 * HOUR)
                    return ts.Hours + " hours ago";

                if (delta < 48 * HOUR)
                    return "yesterday";
                //@Check DateTime Exten
                if (ExtendPast48Hours)
                {

                    if (delta < 30 * DAY)
                        return ts.Days + " days ago";

                    if (delta < 12 * MONTH)
                    {
                        int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                        return months <= 1 ? "one month ago" : months + " months ago";
                    }
                    else
                    {
                        int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                        return years <= 1 ? "one year ago" : years + " years ago";
                    }

                }
                else
                {
                    return yourDate.ToLongDateString() + " at " + yourDate.ToShortTimeString();
                }

            }
            catch (Exception)
            {
                return yourDate.ToLongDateString() + " at " + yourDate.ToShortTimeString();
            }

        }
    }
}
