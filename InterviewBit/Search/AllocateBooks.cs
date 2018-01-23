using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Search
{
    public class AllocateBooks : ISolution
    {
        public override void Solve()
        {
            var bookLi = ReadArrString().Select(int.Parse).ToList();
            var m = ReadInt();
            books(bookLi, m);
        }

        public int books(List<int> A, int B)
        {
            if (A.Count == 1)
                return A[0];
            bool isValidPartition = false;
            long min = A.Min(), max = A[0], lo = min, hi, mid;
            for (int i = 1; i < A.Count; i++)
            {
                max += A[i];
            }
            hi = max;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                if (isValid(A, mid, B))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return  (int)lo;
        }

        private bool isValid(List<int> a, long mid, int b)
        {
            int partitionCounter = 0;
            long sum = 0;
            for (int i = 0; i < a.Count; i++) {
                if (partitionCounter >= b) {
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
                else {
                    partitionCounter += 1;
                    sum = 0;
                    i--;
                }
            }
            return true;
        }
    }
}
