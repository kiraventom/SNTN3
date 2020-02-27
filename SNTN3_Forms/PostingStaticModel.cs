using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNTN3_Forms.Posting
{
    public static class PostingStaticModel
    {
        private static Random Rnd { get; } = new Random();

        public static DateTime[] GetPostingDateTimes(int postsAmount, DateTime startDateTime, int postsPerDayCount, int maxPostingOffset, int timeBetween)
        {
            var dateTimes = new List<DateTime>();
            int daysCount = (int)Math.Ceiling((double)postsAmount / postsPerDayCount);

            int counter = postsAmount;
            for (int i = 0; i < daysCount; ++i)
            {
                DateTime date = startDateTime.AddDays(i);
                for (int j = 0; counter > 0 && j < postsPerDayCount; ++j)
                {
                    dateTimes.Add(date.AddMinutes(Rnd.Next(-maxPostingOffset, maxPostingOffset)));
                    date = date.AddHours(timeBetween);
                    --counter;
                }
            };

            if (dateTimes.Count != postsAmount)
            {
                throw new Exception($"Количество вычисленных дат не совпадает с количеством постов." +
                                    $"Количество дат: {dateTimes.Count}. Количество постов: {postsAmount}");
            }

            return dateTimes.ToArray();
        }
    }
}
