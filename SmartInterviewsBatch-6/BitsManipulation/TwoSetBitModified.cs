using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.BitsManipulation
{
    public class TwoSetBitModified : ISolution
    {
        static long mod = (long)(1e9 + 7);
        public override void Solve()
        {
            var t = ReadInt();
            while (t-- > 0)
            {
                var n = ReadLong();
                if (n == 1)
                {
                    output.AppendLine("3");
                }
                else if (n == 2)
                {
                    output.AppendLine("5");
                }
                else
                {
                    var prevBucket = Floor(n);
                    var numberOfElementsInPrevBucket = (prevBucket * (prevBucket - 1) / 2);
                    var nthTwoSetBit = ((APowBModM(2, prevBucket, mod) + APowBModM(2, n - (numberOfElementsInPrevBucket + 1), mod)) % mod);
                    output.AppendLine(nthTwoSetBit.ToString());
                }
            }
            Console.Write(output);
        }

        private long Floor(long n)
        {
            long lo = 1, hi = n, mid = 0;
            var ncr = new BigInteger(0);
            var left = new BigInteger(0);
            var right = new BigInteger(0);

            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                left = mid;
                right = mid - 1;
                ncr = BigInteger.Multiply(left, right);
                ncr = BigInteger.Divide(ncr, new BigInteger(2));
                if (ncr == n)
                    return mid - 1;
                else if (ncr > n)
                    hi = mid - 1;
                else if (ncr < n)
                {
                    lo = mid + 1;
                }
            }
            left = mid;
            right = mid - 1;
            var midc2 = BigInteger.Multiply(left, right);
            midc2 = BigInteger.Divide(midc2, new BigInteger(2));
            if (midc2 >= n)
                return mid - 1;
            else
                return mid;
        }

        private long APowBModM(long a, long n, long mod)
        {
            long ans = 1, x = a;
            if (n > 1)
            {
                for (int i = 0; i <= (int)Math.Ceiling(Math.Log(n, 2)); i++)
                {
                    if (((n & (long)(1 << i)) > 0))
                    {
                        ans = ((ans * x) % mod);
                    }
                    x = ((x * x) % mod);
                }
            }
            else
            {
                return (n == 1 ? 2 : 1);
            }

            return ans % mod;
        }
    }
}
