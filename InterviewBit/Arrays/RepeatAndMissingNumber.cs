using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class RepeatAndMissingNumber : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            long sum = 0, sumOfSquares = 0;
            //sum = A - B
            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
                sum -= (i + 1);
                sumOfSquares += ((long)arr[i] * arr[i] - (long)(i + 1) * (i + 1));
            }
            sumOfSquares /= sum;//A+B
            //A
            int A = (int)((sumOfSquares + sum) / 2);
            int B = (int)(sumOfSquares - A);
            
        }
    }
}
