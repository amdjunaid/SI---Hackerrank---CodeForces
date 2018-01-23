using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Strings
{
    public class LargestPalindromicSubstringHard : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0) {
                ReadInt();
                output.AppendLine(Datastructures.ManacherLargestPalindromicSubString.LargestPalindromicSubstring(ReadString()).ToString());
            }
            Console.Write(output);
        }
    }
}
