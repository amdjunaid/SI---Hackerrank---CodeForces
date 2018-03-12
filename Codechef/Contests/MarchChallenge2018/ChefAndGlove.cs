using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchChallenge2018
{
    public class ChefAndGlove : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                var n = ReadInt();
                bool isFrontEnd = true;
                bool isBackEnd = true;
                var fingers = ReadArrString().Select(int.Parse).ToArray();
                var gloves = ReadArrString().Select(int.Parse).ToArray();
                for (int i = 0; i < n; i++) {
                    if (fingers[i] >= gloves[i]) {
                        isFrontEnd = false;
                    }if (fingers[i] > gloves[n - 1 - i]) {
                        isBackEnd = false;
                    }
                }
                if (isFrontEnd && isBackEnd)
                {
                    output.AppendLine("both");
                }
                else
                {
                    if (isFrontEnd)
                    {
                        output.AppendLine("front");
                    }
                    else if (isBackEnd)
                    {
                        output.AppendLine("back");
                    }
                    else
                    {
                        output.AppendLine("none");
                    }
                }
            }
            Console.Write(output);
        }
    }
}
