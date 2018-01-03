using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public static class BinaryRepresentation
    {
        public static void Solve() {
            int t = Convert.ToInt32(Console.ReadLine());
            List<StringBuilder> liBinaryRep = new List<StringBuilder>(t);
            while (t-- > 0)
            {
                long n = Convert.ToInt64(Console.ReadLine());
                StringBuilder binaryRep = new StringBuilder();
                if (n == 0)
                {
                    binaryRep.Append(n);
                }
                else {
                    for (int i = (int)Math.Ceiling(Math.Log((double)n, 2)); i >= 0; i--)
                    {
                        binaryRep.Append(((n & (1 << i)) > 0) ? 1 : 0);
                    }
                    if (binaryRep[0] == '0')
                    {
                        binaryRep = binaryRep.Remove(0, 1);
                    }
                }
                binaryRep.AppendLine();
                liBinaryRep.Add(binaryRep);
            }
            foreach (var item in liBinaryRep) {
                Console.Write(item);
            }
        } 
    }
}
