using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerank.Contests.HackerrankHiringJan26
{
    public class ProgrammingCompetition : ISolution
    {
        public override void Solve()
        {
            string winnerNm = string.Empty;
            short maxSolved = short.MinValue;
            short n = ReadShort();
            while (n-- > 0)
            {
                var hckrInfo = ReadArrString();
                byte pbmsSolved = (byte)(byte.Parse(hckrInfo[2]) - byte.Parse(hckrInfo[1]));
                if (maxSolved < pbmsSolved) {
                    maxSolved = pbmsSolved;
                    winnerNm = hckrInfo[0];
                }
            }
            Console.WriteLine(winnerNm+" "+maxSolved);
        }
    }
}
