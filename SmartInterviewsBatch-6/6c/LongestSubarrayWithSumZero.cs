using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6c
{
    public class LongestSubarrayWithSumZero : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(maxLengthSubarray(arr).ToString());
            }
            Console.Write(output);
        }

        static int maxLengthSubarray(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int sum = 0;
            int maxLength = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (arr[i] == 0 && maxLength == 0)
                    maxLength = 1;

                if (sum == 0)
                    maxLength = i + 1;

                int previousIndex = -1;
                if (dict.ContainsKey(sum))
                {
                    previousIndex = dict[sum];
                }

                if (previousIndex != -1)
                    maxLength = Math.Max(maxLength, i - previousIndex);
                else
                    dict.Add(sum, i);
            }

            return maxLength;
        }
    }
}
