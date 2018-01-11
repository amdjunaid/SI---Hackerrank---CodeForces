using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round456
{
    public class NewYearsEve : ISolution
    {
        public override void Solve()
        {
            ulong[] NandK = ReadArrString().Select(ulong.Parse).ToArray();
            sbyte logN = (sbyte)(NandK[0] != 1 ? Math.Floor(Math.Log(NandK[0], 2)) : 0);
            sbyte i = (NandK[1] >= (ulong)logN ? logN : (sbyte)NandK[1]);
            while (i >= 0)
            {
                ulong result = (ulong)(NandK[0] & (ulong)(1 << i));
                if (result == 0)
                {
                    NandK[0] ^= (ulong)(1 << i--);
                }
                else
                {
                    i--;
                }
            }
            Console.Write(NandK[0]);
        }
    }
}
