using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round455
{
    public class PythonIntendation : ISolution
    {
        public override void Solve()
        {
            int n = ReadInt(),count = 0, k = 1,totalWays = 0;
            int[] noOfForLoops = new int[n + 1];
            int[] noOfWays = new int[n + 1];
            string[] chrArr = new string[n + 1];
            while (n-- > 0)
            {
                string chr = ReadString();
                if (chr.Equals("f")) {
                    count++;
                }
                noOfForLoops[k+1] = count;
                chrArr[k + 1] = chr;
            }
            noOfWays[1] = 1;
            for (int i = 2; i < noOfWays.Length; i++) {
                if (chrArr[i] == "s")
                {
                    noOfWays[i] = noOfForLoops[i] + 1;
                }
                else {
                    noOfWays[i] = 1;
                }
            }
            for (int i = 2; i < n; i++) {
                totalWays += noOfWays[i] > 1 ? noOfWays[i] : 0;
            }
            Console.WriteLine(totalWays == 0 ? 1 : totalWays);
        }
    }
}
