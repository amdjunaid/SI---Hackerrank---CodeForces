using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Bitwise
{
    public class SingleNumber : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            Console.Write(singleNumber(arr).ToString());
        }

        public int singleNumber(List<int> arr)
        {
            int singleNumber = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                singleNumber ^= arr[i];
            }
            return singleNumber;
        }
    }
}
