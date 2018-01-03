using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class ExpressAsPowerOfB : ISolution
    {
        public override void Solve()
        {
            int t = ReadInt();
            while (t-- > 0)
            {
                int n = ReadInt();
                output.AppendLine(IsItExpressable(n) ? "Yes" : "No");
            }
            Console.Write(output);
        }

        private bool IsItExpressable(int n)
        {
            int maxPossibleDivisor = (int)Math.Floor(Math.Sqrt(n));
            int lo = 2, hi = maxPossibleDivisor, mid;
            while (lo <= hi)
            {
                mid = hi + (lo - hi) / 2;
                int relation = IsValid(mid,n);
                if (relation.Equals(0))
                {
                    return true;
                }
                else if (relation.Equals(1))
                {
                    hi = mid - 1;
                }
                else if (relation.Equals(-1))
                {
                    lo = mid + 1;
                }
            }
            return false;
        }

        private int IsValid(int mid,int n)
        {
            double b = Math.Log(n, mid);
            if (b % 1 == 0)
            {
                return 0;
            }
            else {
                int power = (int)Math.Floor(b);
                return AToPowerOfB(mid, power).CompareTo(n);
            }
        }

        private long AToPowerOfB(int a, int b)
        {
            long result = 1;
            long c = a;
            int logB = (int)Math.Ceiling(Math.Log((double)b, 2));

            for (int i = 0; i <= logB; i++)
            {
                if ((b & (1 << i)) != 0) //if iTh bit is set in B
                {
                    result = (result * c);
                }
                c = (c * c);
            }
            return result;
        }
    }
}
