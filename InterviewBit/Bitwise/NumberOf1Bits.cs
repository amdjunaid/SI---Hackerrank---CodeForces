using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Bitwise
{
    public class NumberOf1Bits : ISolution
    {
        public override void Solve()
        {
            var n = Convert.ToInt64(ReadString());
            Console.Write(numSetBits(n).ToString());
        }

        public int numSetBits(long a)
        {
            int count = 0;
            while (a > 0)
            {
                if ((a & 1) > 0)
                {
                    count++;
                }
                a >>= 1;
            }
            return count;
        }
    }
}
