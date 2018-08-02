using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._13
{
    public class Permutation : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            short[] countArr = new short[5001];
            var arr = ReadArrString().Select(short.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                countArr[arr[i]]++;
            }
            int count = 0, cntNumbers = 0;
            for (int i = 1; i <= 5000; i++) {
                if (i > n)
                {
                    count += countArr[i];
                }
                else if (countArr[i] > 1)
                {
                    count += countArr[i] - 1;
                }
                else if (countArr[i] == 0)
                {
                    cntNumbers += 1;
                }
            }
            if (cntNumbers == n)
            {
                Console.Write(n);
            }
            else {
                Console.Write(count);
            }
        }
    }
}
