using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class WordsVowelsConsonants : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                string str = ReadString();
                NoOfPatterns(str);
            }
            Console.Write(output);
        }

        private void NoOfPatterns(string str)
        {
            HashSet<char> vowels = new HashSet<char>();
            vowels.Add('a');
            vowels.Add('A');
            vowels.Add('e');
            vowels.Add('E');
            vowels.Add('i');
            vowels.Add('I');
            vowels.Add('o');
            vowels.Add('O');
            vowels.Add('u');
            vowels.Add('U');

            short wordsCount = 0, vowelsCount = 0, consonentsCount = 0;
            string[] tokens = str.Split(' ');
            for (int j = 0; j < tokens.Length; j++) {
                str = tokens[j];
                if (!string.IsNullOrEmpty(str)) {
                    for (int i = 0; i < str.Length; i++) {
                            if (vowels.Contains(str[i]))
                            {
                                vowelsCount++;
                            }
                            else
                            {
                                consonentsCount++;
                            }
                    }
                    wordsCount++;
                }
            }

            output.AppendFormat("{0} {1} {2}", wordsCount, vowelsCount, consonentsCount);
            output.AppendLine();
        }
    }
}
