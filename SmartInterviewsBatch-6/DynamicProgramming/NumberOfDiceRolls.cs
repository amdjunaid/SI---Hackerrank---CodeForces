using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class NumberOfDiceRolls : ISolution
    {
        static int modulo = (int)(1e9 + 7);
        static int N = (int)1e5 + 1;
        //static int N = (int)20;
        static long[] dp = new long[N];
        public override void Solve()
        {
            dp[0] = 1;
            for (int i = 1; i < dp.Length; i++) {
                dp[i] = -1;
            }
            NoOfWaysToGetSumI(N-1);
            int t = ReadInt();
            while (t-- > 0) {
                output.AppendLine(dp[ReadInt()].ToString());
            }
            Console.Write(output);
        }

        public long NoOfWaysToGetSumI(int i) {
            if (i == 0) return 1;
            if (dp[i] == -1) {
                long sum = 0;
                for (int j = 1; j <= 6; j++) {
                    if (i - j >= 0) {
                        sum = (sum + NoOfWaysToGetSumI(i - j))%modulo;
                    }
                }
                dp[i] = sum;
            }
            return dp[i];
        }
    }
}
