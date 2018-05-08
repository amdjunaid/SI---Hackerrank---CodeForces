using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators.Practise
{
    public class MinCostPath : ISolution
    {
        public override void Solve()
        {
            var stepsCnt = ReadInt();
            var arr = new int[stepsCnt];
            var dp = new int[stepsCnt];
            int i = 0;
            var n = stepsCnt;
            while (stepsCnt-- > 0)
            {
                arr[i++] = ReadInt();
            }
            if (stepsCnt == 1)
            {
                Console.Write(0);
                return;
            }
            for (int j = n - 2; j >= 0; j--)
            {
                int min = int.MaxValue;
                bool isFinalStep = false;
                for (int k = j + 1; k <= arr[j] + j && k != n; k++)
                {
                    if (k == n - 1)
                    {
                        isFinalStep = true;
                        break;
                    }
                    if (min > dp[k])
                    {
                        min = dp[k];
                    }
                }
                if (isFinalStep)
                    dp[j] = 1;
                else
                    dp[j] = min == int.MaxValue ? int.MaxValue : min + 1;
            }
            Console.WriteLine(dp[0] == int.MaxValue ? -1 : dp[0]);
        }
    }
}
