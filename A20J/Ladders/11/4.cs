using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._11
{
    public class _4 : ISolution
    {
        public override void Solve()
        {
            var code = ReadString();
            for (int i = 0; i < code.Length;)
            {
                if (code[i] == '.')
                {
                    output.Append("0");
                    i++;
                }
                else
                {
                    if (i + 1 != code.Length) {
                        if (code[i + 1] == '-')
                        {
                            output.Append("2");
                        }
                        else
                        {
                            output.Append("1");
                        }
                        i += 2;
                    }
                }
            }
            Console.Write(output);
        }
    }
}
