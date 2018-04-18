using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Arrays
{
    public class TwoRepeatedNumbers : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            var arr = ReadArrString().Select(int.Parse).ToArray();
            int xor = arr[0];
            int set_bit_no = 0;
            int x = 0, y = 0;
            int i;
            for (i = 1; i < arr.Length; i++) {
                xor ^= arr[i];
            }
            for (i = 1; i <= arr.Length - 2; i++) {
                xor ^= i;
            }
            set_bit_no = xor & ~(xor - 1);
            for (i = 0; i < arr.Length; i++)
            {
                if ((arr[i] & set_bit_no)!=0)
                    x = x ^ arr[i]; /*XOR of first set in arr[] */
                else
                    y = y ^ arr[i]; /*XOR of second set in arr[] */
            }
            for (i = 1; i <= arr.Length - 2; i++)
            {
                if ((i & set_bit_no)!=0)
                    x = x ^ i; /*XOR of first set in arr[] and {1, 2, ...n }*/
                else
                    y = y ^ i; /*XOR of second set in arr[] and {1, 2, ...n } */
            }

            Console.Write("n The two repeating elements are {0},{1}", x, y);
        }
    }
}
