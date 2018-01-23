using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class WaveArray : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            wave(arr);
        }

        public List<int> wave(List<int> A)
        {
            if (A.Count == 1)
                return A;
            var a = A.ToArray();
            Array.Sort(a);
            for (int i = 0; (i + 1) < a.Length; i += 2) {
                int temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
            }
            return a.ToList();
        }
    }
}
