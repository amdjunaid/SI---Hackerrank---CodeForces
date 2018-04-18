using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class DecodeString : ISolution
    {
        private static HashSet<string> collection = null;
        private static int modulo = (int)(1e9 + 7);
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                ReadInt();
                var n = ReadString();
                //collection = new HashSet<string>();
                //NumberOfPossibilities(0, n, "");
                output.AppendLine(NumberOfPossibilities(n).ToString());
            }
            Console.Write(output);
        }

        private void NumberOfPossibilities(int position, string n, string newStr)
        {
            if (position >= n.Length - 1)
            {
                if (!collection.Contains(newStr))
                {
                    collection.Add(newStr);
                }
                return;
            }
            var nn = string.Empty;
            char ch = (char)((int)n[position] - 48 + 97);
            nn = newStr + ch.ToString();
            NumberOfPossibilities(position + 1, n, nn);

            if (n[position] != '0')
            {
                int num = int.Parse(n.Substring(position, 2));
                if (num >= 0 && num <= 25)
                {
                    nn = newStr + Convert.ToChar(num + 97).ToString();
                    NumberOfPossibilities(position + 2, n, nn);
                }
            }
        }

        private int NumberOfPossibilities(string str)
        {
            if (str.Length == 1)
                return 1;
            long ans = 1, b = 1, c = 1;
            for (int i = str.Length - 2; i >= 0; i--) {
                if (str[i] !='0' && int.Parse(str.Substring(i, 2))<=25) {
                    ans = (b + c) % modulo;
                }
                c = b;
                b = ans;
            }
            return (int)ans;
        }
    }
}
