using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.GoodBye2017
{
    public class CountingCards : ISolution
    {
        public override void Solve()
        {
            string cards = ReadString();
            Console.Write(MinNoOfFlips(cards));
        }

        private sbyte MinNoOfFlips(string cards)
        {
            sbyte minNoOfFlips = 0;
            HashSet<char> vowels = new HashSet<char>();
            vowels.Add('a');
            vowels.Add('e');
            vowels.Add('i');
            vowels.Add('o');
            vowels.Add('u');

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] >= 97 && cards[i] <= 122)
                {
                    if (vowels.Contains(cards[i])) {
                        minNoOfFlips++;
                    }
                }
                else if (cards[i] % 2 != 0)
                {
                    minNoOfFlips++;
                }
            }
            return minNoOfFlips;
        }
    }
}
