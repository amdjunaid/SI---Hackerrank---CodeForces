using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._11
{
    public class _2 : ISolution
    {
        public override void Solve()
        {
            byte ith = 0, jth = 0;
            bool found = false;
            for (byte i = 0; i < 5; i++)
            {
                var arr = ReadArrString().Select(byte.Parse).ToArray();
                if (!found)
                {
                    for (byte j = 0; j < 5; j++)
                    {
                        if (arr[j] == 1)
                        {
                            ith = i;
                            jth = j;
                            found = true;
                            break;
                        }
                    }
                }
            }
            Console.Write((int)(Math.Abs(ith - 2) + Math.Abs(jth - 2)));
        }
    }
}
