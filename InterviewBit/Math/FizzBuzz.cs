using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Math
{
    public class FizzBuzz : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            Console.Write(string.Join(" ", fizzBuzz(n)));
        }

        public List<string> fizzBuzz(int A)
        {
            var list = new List<string>(A);
            for (int i = 1; i <= A; i++) {
                string word = string.Empty;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    if (i % 3 == 0)
                    {
                        word += "Fizz";
                    }
                    if (i % 5 == 0)
                    {
                        word += "Buzz";
                    }
                    list.Add(word);
                }
                else {
                    list.Add(i.ToString());
                }
            }
            return list;
        }
    }
}
