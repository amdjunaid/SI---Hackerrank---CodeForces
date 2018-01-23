using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Search
{
    public class SquareRootNumber : ISolution
    {
        public override void Solve()
        {
            int n = ReadInt();
            sqrt(n);
        }

        public int sqrt(int a)
        {
            if (a == 1) return 1;
            long lo = 1, hi = a / 2;
            long mid = 0;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (mid * mid == a)
                    return (int)mid;
                else if (mid * mid < a)
                {
                    lo = mid + 1;
                }
                else if (mid * mid > a)
                {
                    hi = mid - 1;
                }
            }
            return (int)(mid * mid <= a ? mid : mid - 1);
        }
    }
}
