using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Div489
{
    public class NatsyaAndGame : ISolution
    {
        public override void Solve()
        {
            var NandK = ReadArrString().Select(int.Parse).ToArray();
            var arr = ReadArrString().Select(int.Parse).ToArray();

            var prodArr = new long[arr.Length];
            var sumArr = new long[arr.Length];

            prodArr[0] = sumArr[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prodArr[i] = prodArr[i - 1] * arr[i];
                sumArr[i] = sumArr[i - 1] + arr[i];
            }

            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count += isPresent(i, arr, prodArr, sumArr, NandK[1]) ? 1 : 0;
            }
            Console.Write(count);
        }

        public bool isPresent(int i, int[] arr, long[] prodArr, long[] sumArr, int k)
        {
            int lo = i, hi = arr.Length - 1, mid = 0;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                long prod = prodArr[mid] / (i != 0 ? prodArr[i - 1] : 1);
                long sum = sumArr[mid] - (i != 0 ? sumArr[i - 1] : 0);
                if (prod / sum == k)
                    return true;
                else if (prod / sum > k)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return prodArr[lo] / sumArr[lo] == k ? true : false;
        }
    }
}
