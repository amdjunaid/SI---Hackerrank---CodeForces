using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class MaxSubArraySum : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(MaxSubArraySumIs(arr));
            }
            Console.Write(output);
        }

        private string MaxSubArraySumIs(int[] arr)
        {
            int max_so_far = int.MinValue, max_ending_here = 0, start = 0, end = 0, s = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                max_ending_here += arr[i];

                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                    start = s;
                    end = i;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    s = i + 1;
                }
            }
            return string.Format("{0} {1} {2}", max_so_far, start, end);
        }
    }
}
