using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class GameOfLetters : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                var input = ReadString();
                output.AppendLine(WhoWins(input));
            }
            Console.Write(output);
        }

        private string WhoWins(string s)
        {
            int nimSum = 0;
            int[] cntArr = new int[26];
            for (int i = 0; i < s.Length; i++) {
                cntArr[s[i] - 'a']++;
            }
            for (int i = 0; i < 26; i++) {
                nimSum ^= cntArr[i] > 0 ? cntArr[i] : 0;
            }
            return nimSum == 0 ? "Banta" : "Santa";
        }
    }
}
