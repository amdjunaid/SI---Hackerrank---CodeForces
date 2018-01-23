using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Search
{
    public class PaintersPartitionProblem : ISolution
    {
        public override void Solve()
        {
            var K = ReadInt();
            var T = ReadInt();
            var paintLi = ReadArrString().Select(int.Parse).ToList();
            paint(K,T,paintLi);
        }

            public int paint(int K, int B, List<int> A)
            {
                if (A.Count == 1)
                    return A[0]*B;
                var A1 = new List<long>(A.Select(x => long.Parse(x.ToString())).ToList());
                long min = long.MaxValue,ans = 0, max = 0, lo, hi, mid;
                for (int i = 0; i < A.Count; i++)
                {
                    A1[i] *= B;
                    max += A1[i];
                    min = System.Math.Min(min, A1[i]);
                }
                hi = max;
                lo = min;
                while (lo <= hi)
                {
                    mid = lo + (hi - lo) / 2;
                    if (isValid(A1, mid, K))
                    {
                        ans = mid;
                        hi = mid-1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                return (int)(ans % 10000003);
            }

            private bool isValid(List<long> a, long mid, int b)
            {
                int partitionCounter = 0;
                long sum = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    if (partitionCounter >= b)
                    {
                        return false;
                    }
                    sum += a[i];
                    if (sum < mid)
                    {
                        continue;
                    }
                    else if (sum == mid)
                    {
                        partitionCounter += 1;
                        sum = 0;
                    }
                    else
                    {
                        partitionCounter += 1;
                        sum = 0;
                        i--;
                    }
                }
                return true;
            }
    }
}
