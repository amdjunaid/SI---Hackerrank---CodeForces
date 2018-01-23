using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class MinStepsInfiniteGrid : ISolution
    {
        public override void Solve()
        {
            int t = ReadInt();
            while (t-- > 0)
            {
                var xarr = ReadArrString().Select(int.Parse).ToList();
                var yarr = ReadArrString().Select(int.Parse).ToList();
                output.AppendLine(coverPoints(xarr, yarr).ToString());
            }
            Console.Write(output);
        }

        public int coverPoints(List<int> A, List<int> B)
        {
            if (A.Count == 1)
            {
                return 0;
            }
            int minSteps = 0;
            for (int i = 0; i < A.Count - 1; i++)
            {
                minSteps += System.Math.Max(System.Math.Abs(A[i] - A[i + 1]), System.Math.Abs(B[i] - B[i + 1]));
            }
            return minSteps;
        }
    }
}
