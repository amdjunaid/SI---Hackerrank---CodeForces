using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round448
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PythonIntendation : IISolution
    {
        public override void Solve()
        {
            int n = ReadInt(), count = 0, k = 1, totalWays = 0;
            int[] noOfForLoops = new int[n + 1];
            int[] noOfWays = new int[n + 1];
            string[] chrArr = new string[n + 1];
            while (n-- > 0)
            {
                string chr = ReadString();
                if (chr.Equals("f"))
                {
                    count++;
                }
                noOfForLoops[k] = count;
                chrArr[k] = chr;
                k++;
            }
            noOfWays[1] = 1;
            for (int i = 2; i < noOfWays.Length; i++)
            {
                if (chrArr[i - 1] == "s")
                {
                    noOfWays[i] = noOfForLoops[i-1] + 1;
                }
                else
                {
                    noOfWays[i] = 1;
                }
            }
            for (int i = 2; i < noOfForLoops.Length; i++)
            {
                totalWays += noOfWays[i] > 1 ? noOfWays[i] : 0;
            }
            Console.WriteLine(totalWays == 0 ? 1 : totalWays);
        }
    }

    public abstract class IISolution
    {
        public static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        public static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        public static Func<string> ReadString = () => Console.ReadLine().Trim();
        public static Func<byte> ReadByte = () => byte.Parse(Console.ReadLine().Trim());
        public static StringBuilder output = new StringBuilder();
        public static Func<string[]> ReadArrString = () => ReadString().Split(' ').ToArray();
        public abstract void Solve();
    }
}
