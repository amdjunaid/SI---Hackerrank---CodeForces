using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class LargestConcatinatedNumber : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                short N = ReadShort();
                var elements = ReadString().Split(' ').ToArray();
                TheLargestConcatinatedNumber(elements);
            }
            Console.Write(output);
        }

        /// <summary>
        /// logic: start comparing the digits from start till the end. if any of the starting aren't equal, the order is as per the descending.
        /// in the case of numbers of varying digits size, Ex: A and B are two strings. A is of 2 digits and B is of 3 digits
        /// </summary>
        /// <param name="elements"></param>
        private void TheLargestConcatinatedNumber(string[] elements)
        {
            Array.Sort(elements, delegate (string a, string b)
            {
                string A = a.Length > b.Length ? b : a, B = a.Length > b.Length ? a : b;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i].CompareTo(B[i]).Equals(0))
                    {
                        continue;
                    }
                    return A == a ? A[i].CompareTo(B[i]) : B[i].CompareTo(A[i]);
                }
                for (int i = A.Length; i < B.Length; i++)
                {
                    if (A[0].CompareTo(B[i]).Equals(0))
                    {
                        if (B.Length - i == 1)
                        {
                            return A == a ? A[A.Length-1].CompareTo(B[i]) : B[i].CompareTo(A[A.Length-1]);
                        }
                        else {
                            continue;
                        }
                    }
                    return A == a ? A[0].CompareTo(B[i]) : B[i].CompareTo(A[0]);
                }
                return 0;
            });
            for (short i = (short)(elements.Length - 1); i >= 0; i--)
            {
                output.Append(elements[i]);
            }
            output.AppendLine();
        }
    }
}
