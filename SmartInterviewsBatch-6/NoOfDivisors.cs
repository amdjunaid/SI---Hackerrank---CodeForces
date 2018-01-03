using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class NoOfDivisors : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0) {
                int N = ReadInt();
                output.AppendLine(DivisorsCount(N).ToString());
            }
            Console.WriteLine(output);
        }

        private int DivisorsCount(int n)
        {
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(n) + 1; i++)
            {
                if (n % i == 0)
                {
                    if (n / i == i)
                        count++;
                    else
                        count += 2;
                }
            }
            return count;
        }
    }
}
