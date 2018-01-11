using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Hello2018
{
    public class ModularExponentiation : ISolution
    {
        public override void Solve()
        {
            int n = ReadInt();
            int m = ReadInt();
            if (n >= 27)
            {
                Console.Write(m);
            }
            else
            {
                Console.Write(m % Math.Pow(2, n));
            }
        }
    }
}
