using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class RoboticExhibition
    {
        public void Solve()
        {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                Console.ReadLine();
                var arr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                output.AppendLine(Exists(arr).ToString());
            }
            Console.Write(output);
        }

        private int Exists(int[] arr)
        {
            Array.Sort(arr);
            int smallestNumber = 1;
            for (int i = 0; i < arr.Length && smallestNumber >= arr[i]; i++) {
                smallestNumber += arr[i];
            }
            return smallestNumber;
        }
    }
}
