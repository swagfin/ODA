using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Libraries
{
    public static class TimeElapse
    {
        public static string Format(DateTime yourDate)
        {
            const int SECOND = 1;
            const int MINUTE_MINIMUM = 30 * SECOND;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            //const int MONTH = 30 * DAY;

            try
            {
                yourDate = yourDate.ToUniversalTime();
                var ts = new TimeSpan(yourDate.Ticks - DateTime.UtcNow.Ticks);
                double delta = Math.Abs(ts.TotalSeconds);

                if (delta < 1 * MINUTE_MINIMUM)
                    return "just now";

                if (delta < 1 * MINUTE)
                    return ts.Seconds == 1 ? "one second" : ts.Seconds + " seconds";

                if (delta < 2 * MINUTE)
                    return "a minute";

                if (delta < 45 * MINUTE)
                    return ts.Minutes + " minutes";

                if (delta < 90 * MINUTE)
                    return "an hour";

                if (delta < 24 * HOUR)
                    return ts.Hours + " hours";

                return ts.Days + " days";

            }
            catch (Exception)
            {
                return yourDate.ToLongDateString() + " at " + yourDate.ToShortTimeString();
            }

        }
    }
}
