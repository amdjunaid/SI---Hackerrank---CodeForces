using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round456
{
    public class TrickyAlchemy : ISolution
    {
        public override void Solve()
        {
            var AandB = ReadArrString().Select(long.Parse).ToArray();
            var xyz = ReadArrString().Select(long.Parse).ToArray();

            long min = 0;
            //yellow
            if (AandB[0] - 2 * xyz[0] >= 0)
            {
                AandB[0] -= 2 * xyz[0];
            }
            else {
                min += Math.Abs(AandB[0] - 2 * xyz[0]);
                AandB[0] = 0;
            }
            //green
            if (AandB[0] - xyz[1] >= 0)
            {
                AandB[0] -= xyz[1];
            }
            else {
                min += Math.Abs(AandB[0] - xyz[1]);
                AandB[0] = 0;
            }
            if (AandB[1] - xyz[1] >= 0)
            {
                AandB[1] -= xyz[1];
            }
            else
            {
                min += Math.Abs(AandB[1] - xyz[1]);
                AandB[1] = 0;
            }
            //blue
            if (AandB[1] - 3 * xyz[2] >= 0)
            {
                AandB[1] -= 3 * xyz[2];
            }
            else {
                min += Math.Abs(AandB[1] - 3 * xyz[2]);
                AandB[1] = 0;
            }
            Console.Write(min);
        }
    }
}
