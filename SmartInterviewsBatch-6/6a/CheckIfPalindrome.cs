using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class CheckIfPalindrome : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                short N = ReadShort();
                string str = ReadString();
                output.AppendLine(CheckIfPalindromeOrNot(str, N) == true ? "Yes" : "No");
            }
            Console.Write(output);
        }

        private bool CheckIfPalindromeOrNot(string str, int n)
        {
            if (n % 2 == 0)
            {
                int mid = (n / 2);
                int P1 = mid - 1;
                int P2 = mid;
                while (P1 >= 0 && P2 < str.Length)
                {
                    if (str[P1] == str[P2])
                    {
                        P1--;
                        P2++;
                        continue;
                    }
                    else
                        return false;
                }
                return true;
            }
            else {
                int mid = (n / 2);
                int P1 = mid - 1;
                int P2 = mid + 1;
                while (P1 >= 0 && P2 < str.Length)
                {
                    if (str[P1] == str[P2])
                    {
                        P1--;
                        P2++;
                        continue;
                    }
                    else
                        return false;
                }
                return true;
            }
        }
    }
}
