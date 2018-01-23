using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class MaxContiguousSubArray : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            output.AppendLine(maxSubArray(arr).ToString());
            Console.Write(output);
        }


        public long maxSubArray(List<int> A)
        {
            long curr = A[0],ans = 0;
            for (int i = 1; i < A.Count; i++)
            {
                curr = System.Math.Max(curr + A[i], A[i]);
                ans = System.Math.Max(ans, curr);
            }
            return ans;
        }
    }
}
