using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._13
{
    public class LittleElephantAndChess : ISolution
    {
        public override void Solve()
        {
            bool isPossible = true;
            string[] Brd = new string[8];
            for (int i = 0; i < 8; i++) {
                int cntW = 0, cntB = 0;
                var row = ReadString();
                if (row[0].Equals('W'))
                    cntW++;
                else
                    cntB++;
                for (int j = 1; j < row.Length; j++) {
                    if (row[j].Equals('W'))
                        cntW++;
                    else
                        cntB++;
                    if (row[j] == row[j - 1])
                    {
                        isPossible = false;
                        break;
                    }
                }
                if (cntB != cntW)
                    isPossible = false;
                Brd[i] = row;
            }
            Console.Write(isPossible ? "YES" : "NO");
        }
    }
}
