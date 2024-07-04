namespace MiniCoreEnriqueMerizalde.Controllers
{
    using System;

    public static class DateExtensions
    {
        public static DateTime AddWeekdays(this DateTime startDate, int numberOfDays)
        {
            if (numberOfDays < 0)
                throw new ArgumentException("Number of days must be non-negative.");

            DateTime endDate = startDate;
            int daysAdded = 0;

            while (daysAdded < numberOfDays)
            {
                endDate = endDate.AddDays(1);
                if (endDate.DayOfWeek != DayOfWeek.Saturday && endDate.DayOfWeek != DayOfWeek.Sunday)
                    daysAdded++;
            }

            return endDate;
        }

        public static int GetWeekdaysBetween(DateTime start, DateTime end)
        {
            if (start > end)
                throw new ArgumentException("Start date must be before end date.");

            int weekdays = 0;
            DateTime currentDate = start;

            while (currentDate < end)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    weekdays++;

                currentDate = currentDate.AddDays(1);
            }

            return weekdays;
        }
    }
}
