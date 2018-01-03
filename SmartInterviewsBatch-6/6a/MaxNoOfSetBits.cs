using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class MaxNoOfSetBits : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ulong n = ulong.Parse(ReadString());
                output.AppendLine(MaximumSetBits(n).ToString());
            }
            Console.Write(output);
        }

        private int MaximumSetBits(ulong n)
        {
            int count = 0;

            while (n != 0)
            {
                n = (n & (n << 1));
                count++;
            }
            return count;
        }
    }
}
