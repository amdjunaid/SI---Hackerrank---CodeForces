using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6c
{
    public class PalindromicConcatination : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                int check = -1;
                int[] keys = new int[26];
                for (int i = 0; i < 26; i++)
                {
                    keys[i] = 0;
                }
                var strings = ReadArrString().ToArray();
                foreach (char item in strings[0])
                {
                    keys[item - 'a'] = (keys[item - 'a']) + 1;
                }
                foreach (char item in strings[1])
                {
                    if (keys[item - 'a'] >= 1)
                    {
                        check = 0;
                        Console.WriteLine("Yes");
                        break;
                    }
                    else
                    {
                        check = 1;

                    }
                }
                if (check == 1)
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
