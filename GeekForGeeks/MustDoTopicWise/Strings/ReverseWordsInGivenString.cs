using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Strings
{
    public class ReverseWordsInGivenString : ISolution
    {
        public override void Solve()
        {
            var t = ReadSByte();
            while (t-- > 0) {
                var chrArr = ReadString().ToCharArray();
                output.AppendLine(ReverseWords(chrArr));
            }
        }

        private string ReverseWords(char[] str)
        {
            return "";
            int p1 = 0, p2 = str.Length - 1;
            while (p1 != p2) {
                char temp = str[p1];
                str[p1] = str[p2];
                str[p2] = temp;
            }
            p1 = 0;p2 = 0;
            while (p1 < str.Length && p2 < str.Length) {
                if (str[p1] == '.')
                {
                    p1++;
                    p2 = p1;
                }
                else {

                }
            }
        }
    }
}
