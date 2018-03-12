using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round468
{
    public class WorldCup : ISolution
    {
        public override void Solve()
        {
            var NandAandB = ReadArrString().Select(int.Parse).ToArray();
            var cntArr = new bool[NandAandB[0] + 1];
            int rounds = 0;
            int minTeamId = Math.Min(NandAandB[1], NandAandB[2]);
            int maxTeamId = Math.Max(NandAandB[1], NandAandB[2]);
            for (int i = 1; i < cntArr.Length; i++)
            {
                rounds++;
                int j = 1;
                int indexFirstTeam = int.MinValue;
                int indexSndTeam = int.MinValue;
                while (j < cntArr.Length)
                {
                    if (cntArr[j] == false)
                    {
                        if (indexFirstTeam < 0)
                        {
                            indexFirstTeam = j;
                        }
                        else if (indexSndTeam < 0)
                        {
                            indexSndTeam = j;
                        }
                        if (indexFirstTeam >= 0 && indexSndTeam >= 0)
                        {
                            if (indexFirstTeam == minTeamId)
                            {
                                if (indexSndTeam == maxTeamId)
                                {
                                    if (rounds == Math.Ceiling(Math.Log(NandAandB[0], 2)))
                                    {
                                        Console.WriteLine("Final!");
                                    }
                                    else
                                    {
                                        Console.WriteLine(rounds);
                                    }
                                    return;
                                }
                                else
                                {
                                    cntArr[indexSndTeam] = true;
                                }
                            }
                            else if (indexFirstTeam == maxTeamId)
                            {
                                cntArr[indexSndTeam] = true;
                            }
                            else
                            {
                                cntArr[indexFirstTeam] = true;
                            }
                            indexFirstTeam = int.MinValue;
                            indexSndTeam = int.MinValue;
                        }
                    }
                    j++;
                }
            }
        }
    }
}
