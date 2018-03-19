using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchCookOff2018
{
    public class ChefGoesToCinema : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                var x = ReadLong();
                var floorStation = Floor(x);
                var ceilStation = Ceil(x);
                var minSteps = floorStation + (floorStation == x ? 0 : Math.Min(1 + (ceilStation*(ceilStation+1)/2) - x, x - (floorStation*(floorStation+1)/2)));
                output.AppendLine(minSteps.ToString());
            }
            Console.Write(output);
        }

        public long Floor(long key) {
            long lo = 1, hi = key, mid = 0;
            while (lo < hi) {
                mid = lo + (hi - lo + 1) / 2;
                if ((mid * (mid + 1) / 2) <= key)
                    lo = mid;
                else
                    hi = mid - 1;
            }
            return lo;
        }

        public long Ceil(long key)
        {
            long lo = 1, hi = key, mid = 0;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                if ((mid * (mid + 1) / 2) >= key)
                    hi = mid;
                else
                    lo = mid + 1;
            }
            return lo;
        }
    }
}
