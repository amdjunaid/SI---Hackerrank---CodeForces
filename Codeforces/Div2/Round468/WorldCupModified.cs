using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round468
{
    public class WorldCupModified : ISolution
    {
        public override void Solve()
        {
            var NandAandB = ReadArrString().Select(int.Parse).ToArray();
            var maxNoOfRounds = (int)Math.Floor(Math.Log(NandAandB[0], 2));
            var firstTeamId = Math.Min(NandAandB[1], NandAandB[2]);
            bool isFirstQuadrantEven = false, isScndQuadrantOdd = false;
            if (firstTeamId % 2 == 0) {
                firstTeamId--;
                isFirstQuadrantEven = true;
            }
            var scndTeamId = Math.Max(NandAandB[1], NandAandB[2]);
            if (scndTeamId % 2 != 0) {
                scndTeamId++;
                isScndQuadrantOdd = true;
            }
            var noOfMatchesBetweenIncludingTwoTeams = scndTeamId - firstTeamId + 1;
            var roundTheyMeet = (Math.Log(noOfMatchesBetweenIncludingTwoTeams, 2));
            if (roundTheyMeet % 1 == 0) // if it is a power of 2
            {
                if (isFirstQuadrantEven && isScndQuadrantOdd)
                {
                    Console.WriteLine(Math.Floor(roundTheyMeet) + 1== maxNoOfRounds ? "Final!" : Math.Floor(roundTheyMeet + 1).ToString());
                }
                else {
                    Console.WriteLine(Math.Floor(roundTheyMeet) == maxNoOfRounds ? "Final!" : Math.Floor(roundTheyMeet).ToString());
                }
            }
            else
            {
                Console.WriteLine((Math.Floor(roundTheyMeet) + 1) == maxNoOfRounds ? "Final!" : Math.Floor(roundTheyMeet).ToString());
            }
        }
    }
}
