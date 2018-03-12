using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class IntersectionOfSortedArrays : ISolution
    {
        public override void Solve()
        {
            var A = ReadArrString().Select(int.Parse).ToList();
            var B = ReadArrString().Select(int.Parse).ToList();
            var tempoutput = intersect(A, B);
            Console.WriteLine(string.Join("",tempoutput));
        }

        public List<int> intersect(List<int> A, List<int> B)
        {
            var intersection = new List<int>();
            int p1 = 0, p2 = 0;
            while (p1 < A.Count && p2 < B.Count) {
                if (A[p1] == B[p2])
                {
                    intersection.Add(A[p1]);
                    p1++;
                    p2++;
                }
                else if (A[p1] < B[p2])
                {
                    p1++;
                }
                else {
                    p2++;
                }
            }
            return intersection;
        }
    }
}
