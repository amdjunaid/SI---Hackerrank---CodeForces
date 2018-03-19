using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class FareWellParty
    {
        public void Solve()
        {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine().Trim());
                long[] cnt = new long[86401];
                while (n-- > 0) {
                    var AandB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                    cnt[AandB[0]]++;
                    cnt[AandB[1]]--;
                }
                long ans = cnt[0];
                for (int i = 1; i < cnt.Length; i++) {
                    cnt[i] += cnt[i - 1];
                    ans = Math.Max(ans, cnt[i]);
                }

                output.AppendLine(ans.ToString());
            }
            Console.Write(output);
        }
    }
}
