using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class MaximumCircularSubarraySum : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(short.Parse).ToList();
                output.AppendLine(MaxSumIsModified(arr).ToString());
            }
            Console.Write(output);
        }

        private int MaxSumIs(List<short> arr)
        {
            arr.AddRange(arr.GetRange(0, arr.Count / 2));
            int ans = 0, curr = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                curr = Math.Max(curr + arr[i], arr[i]);
                ans = Math.Max(ans, curr);
            }
            return ans;
        }

        private int MaxSumIsModified(List<short> arr)
        {
            int ans = 0, sum = 0;
            short max = arr.Max();
            short min = arr.Min();
            if (max <= 0)
                return max;
            ans = kadane(arr);
            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
                arr[i] = (short)(arr[i] * -1);
            }
            if (min >= 0)
                return sum;
            sum = sum + kadane(arr);
            return Math.Max(sum, ans);
        }

        private int kadane(List<short> arr)
        {
            int ans = 0, curr = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                curr += arr[i];
                if (curr < 0)
                {
                    curr = 0;
                }
                ans = Math.Max(ans, curr);
            }
            return ans;
        }
    }
}
