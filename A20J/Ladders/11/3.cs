using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._11
{
    public class _3 : ISolution
    {
        public override void Solve()
        {
            var NandT = ReadArrString().Select(byte.Parse).ToArray();
            var sequence = new StringBuilder(ReadString());
            if (sequence.Length != 1) {
                while (NandT[1]-- > 0)
                {
                    for (int i = 0; i < sequence.Length - 1;)
                    {
                        if (sequence[i] == 'B' && sequence[i + 1] == 'G')
                        {
                            char temp = sequence[i + 1];
                            sequence[i + 1] = sequence[i];
                            sequence[i] = temp;
                            i += 2;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            Console.Write(sequence);
        }
    }
}
