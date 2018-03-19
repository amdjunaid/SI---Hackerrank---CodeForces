using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class MaximumSetBits
    {
        public void Solve()
        {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine().Trim());
                output.AppendLine(MaxSetBits(n).ToString());
            }
            Console.Write(output);
        }

        private int MaxSetBits(int n)
        {
            if (n == 0) return 0;
            int maxBitLength = (int)Math.Floor(Math.Log(n, 2)), count = 0;
            for (int i = 0; i <= maxBitLength; i++)
            {
                if (((n & (1 << i)) != 0) && ((n & (1 << i + 1)) != 0))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
