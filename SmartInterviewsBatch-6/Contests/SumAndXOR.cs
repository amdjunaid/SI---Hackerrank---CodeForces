using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class SumAndXOR
    {
        public void Solve()
        {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                var n = long.Parse(Console.ReadLine().Trim());
                output.AppendLine(Number(n).ToString());
            }
            Console.Write(output);
        }

        public long Number(long n)
        {
            long lo = 1, hi = n, mid = 0, ans = 0;
            while (lo < hi)
            {
                mid = lo + (hi - lo + 1) / 2;
                if ((mid + n) <= (mid ^ n))
                {
                    lo = mid + 1;
                    ans = mid;
                }
                else if ((mid + n) > (mid ^ n))
                {
                    hi = mid - 1;
                }
                else {
                    lo = mid + 1;
                }
            }
            if ((ans + n) == (ans ^ n))
            {
                return mid;
            }
            else if ((mid + n) > (mid ^ n))
            {
                return mid - 1;
            }
            else
            {
                return mid + 1;
            }
        }
    }
}
