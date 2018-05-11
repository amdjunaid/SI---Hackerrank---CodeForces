using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators.SemiFinals
{
    public class BenTheBear : ISolution
    {
        class Salmon
        {
            public short Id { get; set; }
            public int length { get; set; }
            public int time { get; set; }
            public HashSet<short> enclosingLi { get; set; }
            public HashSet<short> overlappingLi { get; set; }
            public short overlappingCost { get; set; }
            public short maxCost { get; set; }
            //public short maxCostId { get; set; }
            public short enclosingCost { get; set; }
            public short MaxCostEnclosingSalmonId { get; set; }
        }

        Salmon[] salmonsArr = null;
        static short ans = short.MinValue;

        public override void Solve()
        {
            var n = ReadShort();
            salmonsArr = new Salmon[n + 1];
            var lengthArr = ReadArrString().Select(int.Parse).ToArray();
            var timeArr = ReadArrString().Select(int.Parse).ToArray();
            for (short i = 1; i < salmonsArr.Length; i++)
            {
                salmonsArr[i] = new Salmon
                {
                    Id = i,
                    length = lengthArr[i - 1],
                    time = timeArr[i - 1],
                    enclosingCost = -1
                };
            }

            PopulateNeighbours();

            for (short i = 1; i < salmonsArr.Length; i++)
            {
                ComputeMaxCostPerSalmon(-1, i);
            }

            //replace enclosingLi with optimal neighbourhood group
            for (short i = 1; i < salmonsArr.Length; i++)
            {
                salmonsArr[i].enclosingLi = ComputeOptimalNeighbourHood(-1, i, new HashSet<short>());
            }

            FindMaxPair();

            Console.Write(ans);
        }

        private void FindMaxPair()
        {
            for (short i = 1; i < salmonsArr.Length; i++)
            {
                var currSalmon = salmonsArr[i];
                short localAns = currSalmon.maxCost;
                //enclosingLi is now replaced with the optimal neighbourgroup of currSalmon
                //HashSet<short> neighboursToRemove = null;
                //var overlappingCostIsHigher = false;
                if (currSalmon.overlappingCost != currSalmon.enclosingCost)
                {
                    //neighboursToRemove = currSalmon.enclosingLi;
                    ans = Math.Max(ans, (short)(localAns + MaxPossibleSalmonCount(i, false)));
                }
                else
                {
                    ans = Math.Max(ans, (short)(localAns + Math.Max(MaxPossibleSalmonCount(i, false), MaxPossibleSalmonCount(i, true))));
                }
            }
        }

        private short MaxPossibleSalmonCount(short currSalmonId, bool chooseOverlapping)
        {
            HashSet<short> neighboursToRemove = chooseOverlapping ? salmonsArr[currSalmonId].overlappingLi : salmonsArr[currSalmonId].enclosingLi;
            short scndMax = 0;
            for (short j = 1; j < salmonsArr.Length; j++)
            {
                //if jth salmon is not currSalmon and is not one of the neighbours of the chosen group of curr salmon, consider it
                if (currSalmonId != j)
                {
                    if (!IsPresent(j, currSalmonId, chooseOverlapping))
                    {
                        var jthCost = (short)salmonsArr[j].maxCost;
                        if (IsPresent(currSalmonId, j, false))
                            jthCost -= 1;
                        if (neighboursToRemove.Count != 0)
                        {
                            var enumerater = neighboursToRemove.GetEnumerator();
                            while (enumerater.MoveNext())
                            {
                                if (IsPresent(enumerater.Current, j, false))
                                {
                                    jthCost -= 1;
                                }
                            }
                        }
                        scndMax = Math.Max(scndMax, jthCost);
                    }
                }
            }
            return scndMax;
        }

        private HashSet<short> ComputeOptimalNeighbourHood(short parentSalmon, short salmonId, HashSet<short> optimalGrp)
        {
            if (salmonsArr[salmonId].overlappingCost > salmonsArr[salmonId].enclosingCost)
            {
                var enumerater = salmonsArr[salmonId].overlappingLi.GetEnumerator();
                while (enumerater.MoveNext())
                {
                    if (enumerater.Current != parentSalmon)
                        optimalGrp.Add(enumerater.Current);
                }
                return optimalGrp;
            }
            if (salmonsArr[salmonId].MaxCostEnclosingSalmonId != 0)
            {
                optimalGrp.Add(salmonsArr[salmonId].MaxCostEnclosingSalmonId);
                return ComputeOptimalNeighbourHood(salmonId, salmonsArr[salmonId].MaxCostEnclosingSalmonId, optimalGrp);
            }
            return optimalGrp;
        }

        // returns true if a particular salmon is under neighbourhood of given salmon
        private bool IsPresent(short neighbourId, short salmonId, bool chooseOverlapping)
        {
            if (neighbourId == salmonId)
                return true;
            if (salmonsArr[salmonId].overlappingCost > salmonsArr[salmonId].enclosingCost)
            {
                //return (salmonsArr[salmonId].overlappingLi.Contains(neighbourId) || neighbourId == salmonId);
                return (salmonsArr[salmonId].overlappingLi.Contains(neighbourId));
            }
            else if (salmonsArr[salmonId].overlappingCost == salmonsArr[salmonId].enclosingCost)
            {
                if (chooseOverlapping)
                {
                    return salmonsArr[salmonId].overlappingLi.Contains(neighbourId);
                }
                else
                {
                    return salmonsArr[salmonId].enclosingLi.Contains(neighbourId);
                }
            }
            else
            {
                return salmonsArr[salmonId].enclosingLi.Contains(neighbourId);
            }
            //if (!salmonsArr[salmonId].enclosingLi.Contains(neighbourId))
            //    return false;
            //return IsPresent(neighbourId, salmonsArr[salmonId].MaxCostEnclosingSalmonId);
            ////else
            //{
            //    if (!salmonsArr[salmonId].enclosingLi.Contains(neighbourId))
            //        return false;
            //    return IsPresent(neighbourId, salmonsArr[salmonId].MaxCostEnclosingSalmonId);
            //}
        }

        private void PopulateNeighbours()
        {
            for (int i = 1; i < salmonsArr.Length; i++)
            {
                salmonsArr[i].overlappingLi = new HashSet<short>();
                salmonsArr[i].enclosingLi = new HashSet<short>();
                for (int j = 1; j < salmonsArr.Length; j++)
                {
                    if (i != j)
                    {
                        //if start point of jth salmon is within the time frame of ith salmon
                        if (salmonsArr[j].time >= salmonsArr[i].time && salmonsArr[j].time <= salmonsArr[i].length + salmonsArr[i].time)
                        {
                            if (salmonsArr[j].time + salmonsArr[j].length >= salmonsArr[i].time + salmonsArr[i].length)
                            {
                                salmonsArr[i].overlappingLi.Add(salmonsArr[j].Id);
                            }
                            else
                            {
                                salmonsArr[i].enclosingLi.Add(salmonsArr[j].Id);
                            }
                        }
                    }
                }
                //salmonsArr[i].overlappingCost = (short)(salmonsArr[i].overlappingLi.Count + 1);
                salmonsArr[i].overlappingCost = (short)(salmonsArr[i].overlappingLi.Count);
                ans = Math.Max(ans, (short)(salmonsArr[i].overlappingCost + 1));
            }
        }

        /// <summary>
        /// computes enclosing cost and then updates the max for each salmon
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="salmonId"></param>
        /// <returns></returns>
        private short ComputeMaxCostPerSalmon(short parentId, short salmonId)
        {
            if (salmonsArr[salmonId].enclosingLi == null || (salmonsArr[salmonId].enclosingLi != null && salmonsArr[salmonId].enclosingLi.Count == 0))
            {
                salmonsArr[salmonId].enclosingCost = 0;
                salmonsArr[salmonId].maxCost = (short)(salmonsArr[salmonId].overlappingCost + 1);
                return (short)(salmonsArr[salmonId].maxCost - (salmonsArr[salmonId].overlappingLi.Contains(parentId) ? 1 : 0));
            }
            if (salmonsArr[salmonId].enclosingCost != -1)
                return salmonsArr[salmonId].maxCost;
            short enclosingCost = short.MinValue;
            var enumerater = salmonsArr[salmonId].enclosingLi.GetEnumerator();
            while (enumerater.MoveNext())
            {
                var cost = ComputeMaxCostPerSalmon(salmonId, enumerater.Current);
                if (cost > enclosingCost)
                {
                    enclosingCost = cost;
                    salmonsArr[salmonId].MaxCostEnclosingSalmonId = enumerater.Current;
                }
            }
            enclosingCost = (short)(enclosingCost == short.MinValue ? 0 : enclosingCost);
            salmonsArr[salmonId].enclosingCost = enclosingCost;
            salmonsArr[salmonId].maxCost = (short)(Math.Max(salmonsArr[salmonId].overlappingCost, salmonsArr[salmonId].enclosingCost) + 1);
            //update global 1 attempt max
            ans = Math.Max(ans, salmonsArr[salmonId].maxCost);
            return salmonsArr[salmonId].maxCost;
        }
    }
}
