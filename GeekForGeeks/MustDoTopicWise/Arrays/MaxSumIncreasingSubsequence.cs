using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Arrays
{
    public class MaxSumIncreasingSubsequence : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                var n = ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                var dp = new int[arr.Length];
                dp[0] = arr[0];
                int maxAns = dp[0];
                for (int i = 1; i < arr.Length; i++) {
                    int ans = 0;
                    for (int j = i - 1; j >= 0; j--) {
                        if (arr[j] < arr[i]) {
                            ans = Math.Max(ans, dp[j]);
                        }
                    }
                    dp[i] = ans + arr[i];
                    maxAns = Math.Max(maxAns, dp[i]);
                }
                Console.Write(maxAns);
            }
        }
    }
}
