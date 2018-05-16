using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators.SemiFinals
{
    public class TempBobJunaid : ISolution
    {
        class Salmon
        {
            public int Id { get; set; }
            public int length { get; set; }
            public int time { get; set; }
            public HashSet<int> enclosingLi { get; set; }
            public HashSet<int> overlappingLi { get; set; }
            public HashSet<int> distinctLi { get; set; }
            public int overlappingCost { get; set; }
            public int maxCost { get; set; }
            public int maxCostOverlappingId { get; set; }
            public int maxOverlappingCostIncludingThis { get; set; }
            public int enclosingCost { get; set; }
            public int MaxCostEnclosingSalmonId { get; set; }
            //temp for testing
            public int endtime { get; set; }
        }

        Salmon[] salmonsArr = null;
        static int ans = int.MinValue;

        public override void Solve()
        {
            var n = ReadInt();
            salmonsArr = new Salmon[n + 1];
            var lengthArr = ReadArrString().Select(int.Parse).ToArray();
            var timeArr = ReadArrString().Select(int.Parse).ToArray();
            for (int i = 1; i < salmonsArr.Length; i++)
            {
                salmonsArr[i] = new Salmon
                {
                    Id = i,
                    length = lengthArr[i - 1],
                    time = timeArr[i - 1],
                    enclosingCost = -1,
                    endtime = lengthArr[i - 1] + timeArr[i - 1],
                    maxCostOverlappingId = -1
                };
            }
            //temp for sorting for max overlapping cost
            salmonsArr[0] = new Salmon
            {
                Id = -1
            };

            //Array.Sort(salmonsArr, delegate (Salmon x, Salmon y)
            //{
            //    if (x.time.CompareTo(y.time) == 0)
            //    {
            //        return (x.endtime).CompareTo(y.endtime);
            //    }
            //    return x.time.CompareTo(y.time);
            //});

            PopulateNeighbours();

            for (int i = 1; i < salmonsArr.Length; i++)
            {
                //MaxOverlappingCost(-1, i);
                ComputeMaxCostPerSalmon(-1, i);
            }

            //replace enclosingLi with optimal neighbourhood group
            for (int i = 1; i < salmonsArr.Length; i++)
            {
                salmonsArr[i].enclosingLi = ComputeOptimalNeighbourHood(-1, i, new HashSet<int>());
            }

            Array.Sort(salmonsArr, delegate (Salmon x, Salmon y) {
                if (x.Id == -1)
                    return -1;
                if (y.Id == -1)
                    return 1;
                return x.distinctLi.Count.CompareTo(y.distinctLi.Count);
            });

            for (int i = 1; i < salmonsArr.Length; i++)
            {
                int cost = 0,maxOverlappingId = 0;
                var enumerater = salmonsArr[i].overlappingLi.GetEnumerator();
                var isCostAdded = false;
                while (enumerater.MoveNext())  {
                    if (enumerater.Current != i) {
                        if (cost < salmonsArr[enumerater.Current].maxCost)
                        {
                            cost = salmonsArr[enumerater.Current].maxCost + 1;
                            //cost -= (salmonsArr[enumerater.Current].overlappingLi.Contains(i) ? 1 : 0);
                            cost -= IsPresent(i,enumerater.Current) ? 1 : 0;
                            maxOverlappingId = enumerater.Current;
                            if (IsPresent(i, enumerater.Current, false) && !isCostAdded) {
                                cost += 1;
                                isCostAdded = true;
                            }
                        }
                    }
                }
                salmonsArr[i].maxCostOverlappingId = maxOverlappingId;
                //salmonsArr[i].maxOverlappingCostIncludingThis = cost + 1;
                salmonsArr[i].maxOverlappingCostIncludingThis = cost == 0? 1 : cost; // need to change property name
                //ans = Math.Max(ans, cost + 1);
            }

            FindMaxPair();

            Console.Write(ans);
        }

        //private int MaxOverlappingCost(int parentId, int salmonId) {
        //    int maxOverlappingCost = 0, maxOverlappingSalmonId = 0;
        //    if (salmonsArr[salmonId].overlappingLi == null || (salmonsArr[salmonId].overlappingLi != null && salmonsArr[salmonId].overlappingLi.Count == 0))
        //    {
        //        //salmonsArr[salmonId].overlappingCost = 0;
        //        salmonsArr[salmonId].maxCostOverlappingId = 0;
        //        salmonsArr[salmonId].maxOverlappingCostIncludingThis = 1;
        //        return 1;
        //        //salmonsArr[salmonId].maxCost = (int)(salmonsArr[salmonId].overlappingCost + 1);
        //    }
        //    if (salmonsArr[salmonId].maxCostOverlappingId == -1) {
        //        var enumerater = salmonsArr[salmonId].overlappingLi.GetEnumerator();
        //        while (enumerater.MoveNext()) {
        //            if (enumerater.Current != parentId) {
        //                var cost = MaxOverlappingCost(salmonId, enumerater.Current);
        //                if (maxOverlappingCost < cost)
        //                {
        //                    maxOverlappingCost = cost;
        //                    maxOverlappingSalmonId = enumerater.Current;
        //                }
        //            }
        //        }
        //        salmonsArr[salmonId].maxCostOverlappingId = maxOverlappingSalmonId;
        //        salmonsArr[salmonId].maxOverlappingCostIncludingThis = maxOverlappingCost + 1;
        //        //update global answer
        //        ans = Math.Max(ans, maxOverlappingCost + 1);
        //        //if (salmonsArr[salmonId].maxCost < maxOverlappingCost + 1) {
        //        //    //salmonsArr[salmonId].maxCost = maxOverlappingCost + 1;
        //        //    //salmonsArr[salmonId].MaxCostEnclosingSalmonId = salmonsArr[salmonId].maxCostOverlappingId;
        //        //}
        //    }
        //    return salmonsArr[salmonId].maxOverlappingCostIncludingThis;
        //}

        private void FindMaxPair()
        {
            for (int i = 1; i < salmonsArr.Length; i++)
            {
                var currSalmon = salmonsArr[i];
                //var neighbours = salmonsArr[currSalmon.maxCostOverlappingId].enclosingLi;

                if (currSalmon.maxOverlappingCostIncludingThis > currSalmon.maxCost)
                {
                    //check with the neighbors of the overlapping salmon which gave max cost
                    //remove the parent from the neighbour if it is present in the overlapping salmon's neighbour hood
                    ans = Math.Max(currSalmon.maxOverlappingCostIncludingThis + MaxPossibleSalmonCount(currSalmon.maxCostOverlappingId, false),ans);
                }
                else/* if (currSalmon.maxOverlappingCostIncludingThis == currSalmon.maxCost) {*/
                {
                    //check with the neighbors of the overlapping salmon which gave max cost and choose the max between this and overlapping and enclosing

                    int localAns = currSalmon.maxCost;
                    if (currSalmon.overlappingCost != currSalmon.enclosingCost)
                    {
                        //neighboursToRemove = currSalmon.enclosingLi;
                        ans = Math.Max(ans, localAns + MaxPossibleSalmonCount(i, false));
                    }
                    else
                    {
                        ans = Math.Max(ans, localAns + Math.Max(MaxPossibleSalmonCount(i, false), MaxPossibleSalmonCount(i, true)));
                    }
                    if (currSalmon.maxCostOverlappingId != 0) {
                        ans = Math.Max(ans, currSalmon.maxOverlappingCostIncludingThis + MaxPossibleSalmonCount(currSalmon.maxCostOverlappingId, false));
                    }
                }
                //else
                //{
                //    int localAns = currSalmon.maxCost;
                //    //enclosingLi is now replaced with the optimal neighbourgroup of currSalmon
                //    //HashSet<int> neighboursToRemove = null;
                //    //var overlappingCostIsHigher = false;
                //    if (currSalmon.overlappingCost != currSalmon.enclosingCost)
                //    {
                //        //neighboursToRemove = currSalmon.enclosingLi;
                //        ans = Math.Max(ans, localAns + MaxPossibleSalmonCount(i, false));
                //    }
                //    else
                //    {
                //        ans = Math.Max(ans, localAns + Math.Max(MaxPossibleSalmonCount(i, false), MaxPossibleSalmonCount(i, true)));
                //    }
                //}
            }
        }

        private int MaxPossibleSalmonCount(int currSalmonId, bool chooseOverlapping)
        {
            HashSet<int> neighboursToRemove = chooseOverlapping ? salmonsArr[currSalmonId].overlappingLi : salmonsArr[currSalmonId].enclosingLi;
            int scndMax = 0;
            for (int j = 1; j < salmonsArr.Length; j++)
            {
                //if jth salmon is not currSalmon and is not one of the neighbours of the chosen group of curr salmon, consider it
                if (currSalmonId != j)
                {
                    //if j is not a neighbour of currSalmon, then choose it
                    if (!IsPresent(j, currSalmonId, chooseOverlapping))
                    {
                        var jthCost = salmonsArr[j].maxCost;
                        //if currSalmon is a neighbour of jth salmon, deduct one from j's maxcost
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

        private HashSet<int> ComputeOptimalNeighbourHood(int parentSalmon, int salmonId, HashSet<int> optimalGrp)
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
        private bool IsPresent(int neighbourId, int salmonId, bool chooseOverlapping)
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
                salmonsArr[i].overlappingLi = new HashSet<int>();
                salmonsArr[i].enclosingLi = new HashSet<int>();
                salmonsArr[i].distinctLi = new HashSet<int>();
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
                            salmonsArr[i].distinctLi.Add(salmonsArr[j].Id);
                        }
                    }
                }
                //salmonsArr[i].overlappingCost = (int)(salmonsArr[i].overlappingLi.Count + 1);
                salmonsArr[i].overlappingCost = salmonsArr[i].overlappingLi.Count;
                salmonsArr[i].maxCost = salmonsArr[i].overlappingCost + 1;
                ans = Math.Max(ans, salmonsArr[i].maxCost);
            }
        }

        /// <summary>
        /// computes enclosing cost and then updates the max for each salmon
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="salmonId"></param>
        /// <returns></returns>
        private int ComputeMaxCostPerSalmon(int parentId, int salmonId)
        {
            //if no enclosing salmons, then return max cost minus parent if parent is overlapping with current salmon
            if (salmonsArr[salmonId].enclosingLi == null || (salmonsArr[salmonId].enclosingLi != null && salmonsArr[salmonId].enclosingLi.Count == 0))
            {
                salmonsArr[salmonId].enclosingCost = 0;
                //salmonsArr[salmonId].maxCost = (int)(salmonsArr[salmonId].overlappingCost + 1);
                return salmonsArr[salmonId].maxCost - (salmonsArr[salmonId].overlappingLi.Contains(parentId) ? 1 : 0);
            }
            if (salmonsArr[salmonId].enclosingCost != -1)
                return salmonsArr[salmonId].maxCost - (IsPresent(parentId, salmonId) ? 1 : 0);
            //if (salmonsArr[salmonId].enclosingCost != -1)
            //    return salmonsArr[salmonId].maxCost;
            int enclosingCost = int.MinValue;
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
            enclosingCost = enclosingCost == int.MinValue ? 0 : enclosingCost;
            salmonsArr[salmonId].enclosingCost = enclosingCost;
            salmonsArr[salmonId].maxCost = Math.Max(salmonsArr[salmonId].overlappingCost, salmonsArr[salmonId].enclosingCost) + 1;
            //update global 1 attempt max
            ans = Math.Max(ans, salmonsArr[salmonId].maxCost);
            return salmonsArr[salmonId].maxCost - (IsPresent(parentId, salmonId) ? 1 : 0);
        }

        // returns true if a particular salmon is under neighbourhood of given salmon
        private bool IsPresent(int neighbourId, int salmonId)
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
                if (salmonsArr[salmonId].overlappingLi.Contains(neighbourId))
                    return true;
            }
            if (!salmonsArr[salmonId].enclosingLi.Contains(neighbourId))
                return false;
            return IsPresent(neighbourId, salmonsArr[salmonId].MaxCostEnclosingSalmonId);
            //else
            //{
            //    if (!salmonsArr[salmonId].enclosingLi.Contains(neighbourId))
            //        return false;
            //    return IsPresent(neighbourId, salmonsArr[salmonId].MaxCostEnclosingSalmonId);
            //}
        }
    }
}
