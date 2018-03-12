using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Div465
{
    public class FifaAndHisCompany : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            Console.Write(NoOfWays(n).ToString());
        }

        private int NoOfWays(int n)
        {
            int count = 0;
            var factors = (int)Math.Ceiling((double)n/2);
            for (int i = 1; i <= n/2; i++) {
                if (n % i == 0) {
                    count++;
                }
            }
            return count;
        }
    }
}
