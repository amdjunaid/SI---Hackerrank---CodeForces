using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class AddOneToNumber : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            Console.Write(string.Join("", plusOne(arr)));
        }

        public List<int> plusOne(List<int> A)
        {
            int lastOccurenceOfNonZero = A.Count - 1;
            int result = 1;
            int[] newNumber = new int[A.Count + 1];
            
            for (int i = A.Count - 1; i >= 0; i--)
            {
                result += A[i];
                if (result == 10)
                {
                    result = 1;
                    newNumber[i + 1] = 0;
                }
                else if (result == 0) {
                    newNumber[i + 1] = 0;
                }
                else
                {
                    lastOccurenceOfNonZero = i + 1;
                    newNumber[i + 1] = result;
                    result = 0;
                }
            }
            if (result == 0)
            {
                var li = new List<int>();
                for (int i = lastOccurenceOfNonZero; i < newNumber.Length; i++) {
                    li.Add(newNumber[i]);
                }
                return li;
            }
            else
            {
                newNumber[0] = 1;
                return newNumber.ToList();
            }
        }
    }
}
