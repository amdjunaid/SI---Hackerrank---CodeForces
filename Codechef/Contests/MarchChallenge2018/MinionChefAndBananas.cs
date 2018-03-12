using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchChallenge2018
{
    public class MinionChefAndBananas : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0)
            {
                var NandH = ReadArrString().Select(int.Parse).ToArray();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(MinimumRateToEat(arr, NandH[0], NandH[1]).ToString());
            }
            Console.Write(output);
        }

        private int MinimumRateToEat(int[] arr, int N, int H)
        {
            int lo = 1, hi = (int)1e9, mid = 0;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                if (isValid(arr, mid, H))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return lo;
        }

        private bool isValid(int[] arr, int mid, int H)
        {
            long hours = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (hours > H) return false;
                hours += arr[i] / mid + (arr[i] % mid == 0 ? 0 : 1);
            }
            return hours > H ? false : true;
        }
    }
}
