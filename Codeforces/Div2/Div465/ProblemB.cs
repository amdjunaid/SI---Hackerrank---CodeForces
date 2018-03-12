using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Div465
{
    public class ProblemB : ISolution
    {
        public override void Solve()
        {
            sbyte prevKingdom = -1;
            int x = 0, y = 0, silverCoins = 0;
            var n = ReadInt();
            var moves = ReadString();
            for (int i = 0; i < n; i++)
            {
                if (x == y)
                {
                    if (prevKingdom == -1)
                    {
                        if (moves[i] == 'R')
                        {
                            x++;
                            prevKingdom = 0;
                        }
                        else
                        {
                            y++;
                            prevKingdom = 1;
                        }
                    }
                    else if (prevKingdom == 0)
                    {
                        if (moves[i] == 'R')
                        {
                            x++;
                        }
                        else
                        {
                            y++;
                            prevKingdom = 1;
                            silverCoins++;
                        }
                    }
                    else
                    {
                        if (moves[i] == 'R')
                        {
                            x++;
                            prevKingdom = 0;
                            silverCoins++;
                        }
                        else
                        {
                            y++;
                        }
                    }

                }
                else {
                    if (moves[i] == 'R')
                    {
                        x++;
                    }
                    else {
                        y++;
                    }
                }
            }
            Console.Write(silverCoins);
        }
    }
}
