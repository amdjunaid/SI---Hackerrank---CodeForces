using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class MaximumContiguousSubsequence : ISolution
    {
        private static short M = short.MinValue, m = short.MaxValue;
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                short N = ReadShort();
                var arr = new short[N];
                var tokens = ReadArrString();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = short.Parse(tokens[i]);
                    M = Math.Max(M, arr[i]);
                    m = Math.Min(m, arr[i]);
                }
                short[] cntArr = new short[M - m + 1];
                output.AppendLine(MaxContiguousSubsequenceLength(arr, cntArr).ToString());
            }
            Console.Write(output);
        }

        private short MaxContiguousSubsequenceLength(short[] arr, short[] cntArr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                cntArr[arr[i] - m]++;
            }
            short p1 = 0, p2 = 0, ans = 1;
            while (p2 < cntArr.Length)
            {
                if (cntArr[p2] != 0)
                {
                    ans = Math.Max(ans, (short)(p2 - p1 + 1));
                    p2++;
                }
                else
                {
                    p2++;
                    p1 = p2;
                }
            }
            return ans;
        }
    }
}
