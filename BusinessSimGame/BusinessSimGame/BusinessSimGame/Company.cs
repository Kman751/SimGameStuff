using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessSimGame
{
    class Company
    {
        public Company()
        {

        }

        public int[] weeklyUpdate()
        {
            int[] values = new int[5];
            int dayTrend;
            int weekTrend = Random(0, 1);
            if (weekTrend == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    dayTrend = Random(-10, 10) + 2;
                    dayTrend = (dayTrend / Math.Abs(dayTrend)) * ((dayTrend / 6) ^ 4 + 1);
                    values[i] = dayTrend;
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    dayTrend = Random(-10, 10) - 2;
                    dayTrend = (dayTrend / Math.Abs(dayTrend)) * ((dayTrend / 6) ^ 4 + 1);
                    values[i] = dayTrend;
                }
            }

            return values;
        }

        private int Random(int p, int p_2)
        {
            throw new NotImplementedException();
        }
    }
}
