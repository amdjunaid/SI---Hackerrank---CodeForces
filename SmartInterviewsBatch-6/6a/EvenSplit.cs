using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class EvenSplit : ISolution
    {
        public override void Solve()
        {
            int t = ReadInt();
            while (t-- > 0)
            {
                ulong n = ulong.Parse(ReadString());
                output.AppendLine((n % 2) != 0 || (n == 2) || (n==0) ? "No" : "Yes");
            }
            Console.Write(output);
        }
    }
}
