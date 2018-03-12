using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round468
{
    public class FriendsMeeting : ISolution
    {
        public override void Solve()
        {
            var a1 = ReadInt();
            var b1 = ReadInt();
            var a = Math.Min(a1, b1);
            var b = Math.Max(a1, b1);
            var dist = Math.Abs(b - a);
            Console.WriteLine(Math.Min(distance(dist), distance((b - (int)Math.Floor((double)(a + b) / 2))) + distance(((int)Math.Floor((double)(a + b) / 2) - a))));
        }

        public int distance(int k)
        {
            return (k * (k + 1) / 2);
        }
    }
}
