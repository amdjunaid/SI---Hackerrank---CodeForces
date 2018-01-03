using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class AddReverseNumbers : ISolution
    {

        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                string[] numbers = ReadArrString().ToArray();
                output.AppendLine(PrintReversedSum(numbers[0], numbers[1]).ToString());
            }
            Console.Write(output);
        }

        private ulong PrintReversedSum(string num1, string num2)
        {
            return Convert.ToUInt64(string.Join("", num1.Reverse().ToArray())) + Convert.ToUInt64(string.Join("",num2.Reverse().ToArray()));
        }
    }
}
