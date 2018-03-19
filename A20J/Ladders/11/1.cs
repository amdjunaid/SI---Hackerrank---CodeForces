using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._11
{
    public class _1 : ISolution
    {
        public override void Solve()
        {
            var n = ReadByte();
            int sumX = 0, sumY = 0, sumZ = 0;
            while (n-- > 0)
            {
                var arr = ReadArrString().Select(sbyte.Parse).ToArray();
                sumX += arr[0];
                sumY += arr[1];
                sumZ += arr[2];
            }
            Console.WriteLine(sumX == 0 && sumY == 0 && sumZ == 0 ? "YES" : "NO");
        }
    }
}
