using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class MaximumNonAdjacentSubsequenceSum : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                var n = ReadInt();
                var arr = ReadArrString().Select(short.Parse).ToArray();
                output.AppendLine(MaxSumIs(arr).ToString());
            }
            Console.Write(output);
        }

        private int MaxSumIs(short[] arr)
        {
            if (arr.Length == 1)
                return arr[0];
            int[] dp = new int[arr.Length];
            dp[0] = arr[0];
            dp[1] = Math.Max(dp[0], arr[1]);
            int ans = dp[1];
            for (int i = 2; i < arr.Length; i++)
            {
                dp[i] = Math.Max(Math.Max(Math.Max(dp[i - 2], arr[i]), dp[i - 2] + arr[i]),dp[i-1]);
                ans = Math.Max(dp[i], ans);
            }
            return ans;
        }
        /// <summary>
        /// optimized space complexity
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private int MaxSumIsOptimisedSpace(short[] arr)
        {
            if (arr.Length == 1)
                return arr[0];
            int a = arr[0], b = Math.Max(a,arr[1]),c=0,ans = 0;
            for (int i = 2; i < arr.Length; i++)
            {
                c = Math.Max(Math.Max(Math.Max(a, arr[i]), a + arr[i]), b);
                ans = Math.Max(c, ans);
                a = b;
                b = c;
            }
            return ans;
        }
    }
}
