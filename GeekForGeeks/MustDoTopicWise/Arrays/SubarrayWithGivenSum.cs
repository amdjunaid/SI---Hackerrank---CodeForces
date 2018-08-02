using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Arrays
{
    public class SubarrayWithGivenSum : ISolution
    {
        public override void Solve()
        {
            var t = ReadSByte();
            while (t-- > 0)
            {
                var n = ReadArrString().Select(int.Parse).ToArray();
                var arr = ReadArrString().Select(byte.Parse).ToArray();
                var prefix = new int[arr.Length];
                prefix[0] = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    prefix[i] = arr[i] + prefix[i - 1];
                }
                int p1 = 0, p2 = 1;
                bool found = false;
                while (p1 < p2 && p2 < arr.Length)
                {
                    var diff1 = prefix[p2] - (p1 != 0 ? prefix[p1 - 1] : 0);
                    if (diff1 > n[1])
                        p1++;
                    else if (diff1 < n[1])
                        p2++;
                    else
                    {
                        found = true;
                        break;
                    }
                }
                var diff = prefix[p2] - (p1 != 0 ? prefix[p1 - 1] : 0);
                if (diff == n[1])
                    output.AppendLine((p1+1) + " " + (p2+1));
                else
                    output.AppendLine("-1");
            }
            Console.Write(output);
        }
    }
}
