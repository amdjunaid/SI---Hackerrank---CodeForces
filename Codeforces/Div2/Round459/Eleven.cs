using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round459
{
    public class Eleven : ISolution
    {
        public override void Solve()
        {
            HashSet<int> fibonacci = new HashSet<int> { 1 };
            var n = ReadShort();
            int a = 1, b = 1, c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                if (c <= n)
                {
                    if (!fibonacci.Contains(c))
                    {
                        fibonacci.Add(c);
                    }
                    a = b;
                    b = c;
                }
                else {
                    break;
                }
            }
            for (int i = 1; i <= n; i++)
            {
                if (fibonacci.Contains(i))
                {
                    output.Append("O");
                }
                else
                {
                    output.Append("o");
                }
            }
            Console.Write(output);
        }
    }
}
