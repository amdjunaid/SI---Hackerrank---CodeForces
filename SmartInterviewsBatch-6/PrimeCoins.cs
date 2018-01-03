using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class PrimeCoins : ISolution
    {
        public override void Solve()
        {
            int t = ReadInt();
            while (t-- > 0) {
                int n = ReadInt();
                output.AppendLine(n % 6 == 0 ? "Banta" : "Santa");
            }
            Console.Write(output);
        }
    }
}
