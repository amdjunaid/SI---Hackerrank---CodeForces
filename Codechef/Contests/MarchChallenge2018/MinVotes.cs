using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchChallenge2018
{
    public class MinVotes : ISolution
    {
        static int[] arr, votes;
        static long[] prefix;

        /// <summary>
        /// create a prefix sum for calculation of influence in [a,b]
        /// create a vote array to store range votes based on +1 and -1 in [a,b)
        /// for every minion j, do a binary search( ceil on right and floor on left to find the index of the minion i who can receive vote from j)
        /// calculate prefix cumulative sum over votes array to get the final votes for each minion.
        /// </summary>
        public override void Solve()
        {
            var t = ReadInt();
            while (t-- > 0)
            {
                var n = ReadInt();
                arr = ReadArrString().Select(int.Parse).ToArray();
                votes = new int[arr.Length];
                prefix = new long[arr.Length];
                TotalVotesForeachMinion();
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void TotalVotesForeachMinion()
        {
            prefix[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prefix[i] = arr[i] + prefix[i - 1];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    int ceilIndex = FindCeil(arr[i], i + 1, arr.Length - 1);
                    votes[i + 1] += 1;
                    if (ceilIndex != arr.Length - 1)
                    {
                        votes[ceilIndex + 1] += -1;
                    }
                }

                if (i != 0)
                {
                    int floorIndex = FindFloor(arr[i], 0, i - 1);
                    votes[i] += -1;
                    votes[floorIndex] += 1;
                }
            }
            for (int i = 1; i < arr.Length; i++)
            {
                votes[i] += votes[i - 1];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                output.Append(votes[i] + " ");
            }
        }

        private int FindCeil(int key, int loIndex, int hi)
        {
            int mid = 0, lo = loIndex;
            while (lo < hi)
            {
                mid = lo + (hi - lo + 1) / 2;
                long totalInfluence = getInfluence(loIndex, mid - 1);
                if (key < totalInfluence)
                {
                    hi = mid - 1;
                }
                else if (key >= totalInfluence)
                {
                    lo = mid;
                }
            }
            //if influence is greater than A[j], return lo -1, else return lo
            return lo - (key >= getInfluence(loIndex, lo - 1) ? 0 : 1);
        }

        private long getInfluence(int lo, int hi)
        {
            //if (lo == hi) return 0;
            return prefix[hi] - prefix[lo - 1];
        }

        private int FindFloor(int key, int lo, int hiIndex)
        {
            int mid = 0, hi = hiIndex;
            while (lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                long totalInfluence = getInfluence(mid + 1, hiIndex);
                if (key < totalInfluence)
                {
                    lo = mid + 1;
                }
                else if (key >= totalInfluence)
                {
                    hi = mid;
                }
            }
            return lo + (key >= getInfluence(lo + 1, hiIndex) ? 0 : 1);
        }
    }
}
