using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class PowerGame : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                short[] teamA = ReadArrString().Select(x => short.Parse(x)).ToArray();
                short[] teamB = ReadArrString().Select(x => short.Parse(x)).ToArray();
                output.AppendLine(MaximumRoundsACanWin(teamA, teamB).ToString());
            }
            Console.Write(output);
        }

        private int MaximumRoundsACanWin(short[] teamA, short[] teamB)
        {
            Array.Sort(teamA);
            Array.Sort(teamB);
            int lo = 0, roundsWon = 0;
            for (int i = 0; i < teamA.Length; i++)
            {
                var value = FindFloor(teamB, teamA[i], lo);
                if (value.Item1 != int.MinValue)
                {
                    roundsWon += 1;
                    lo += 1;
                }
            }
            return roundsWon;
        }

        private Tuple<int, int> FindFloor(short[] arr, short key, int lo)
        {
            int hi = arr.Length - 1, mid;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                if (arr[mid] < key)
                {
                    hi = mid;
                }
                else if (arr[mid] >= key)
                {
                    hi = mid - 1;
                }
            }
            return key > arr[lo] ? new Tuple<int, int>(arr[lo], lo) : new Tuple<int, int>(int.MinValue, int.MinValue);
        }
    }
}
