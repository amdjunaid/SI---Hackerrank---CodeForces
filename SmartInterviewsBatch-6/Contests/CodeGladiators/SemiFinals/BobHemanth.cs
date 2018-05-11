using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators.SemiFinals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    namespace CodeGladiators
    {
        public class BobHemanth
        {
            //static void Main(string[] args)
            //{
            //    BobTheBear.theRevenant();
            //    //    //Console.ReadKey();
            //}
            public static void theRevenant()
            {

                int n = int.Parse(Console.ReadLine().Trim());
                int[] lengths = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
                int[] times = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
                if (n == 0) { Console.WriteLine(0); return; }
                if (n == 1) { Console.WriteLine(1); return; }

                Dictionary<int, Salmons> salmonDict = new Dictionary<int, Salmons> { };

                for (int i = 0; i < n; i++)
                {
                    salmonDict.Add(i, new Salmons(i, -1 * times[i], lengths[i]));
                }

                int[] distinctPositionsInAscendingOrder = times.Distinct().ToArray();
                Array.Sort(distinctPositionsInAscendingOrder);

                Salmons[] salmonsInAscendingPosition = salmonDict.Values.ToArray();
                Array.Sort(salmonsInAscendingPosition, delegate (Salmons x, Salmons y) {
                    return y.start.CompareTo(x.start);
                });

                Dictionary<int, timeLine> timepointDict = new Dictionary<int, timeLine> { };
                //adding fishes according to each fish and its start
                for (int i = 0; i < n; i++)
                {
                    if (!timepointDict.ContainsKey(salmonsInAscendingPosition[i].start))
                    {
                        timepointDict.Add(salmonsInAscendingPosition[i].start, new timeLine(
                            salmonsInAscendingPosition[i].start, salmonsInAscendingPosition[i].rollno, 1
                            ));
                    }
                    else
                    {
                        timepointDict[salmonsInAscendingPosition[i].start].iTHsalmon.Add(salmonsInAscendingPosition[i].rollno, 1);
                        timepointDict[salmonsInAscendingPosition[i].start].salmonCount++;
                    }
                }
                //adding extension of fishes into timepoints 
                for (int i = 0; i < distinctPositionsInAscendingOrder.Length; i++)
                {
                    foreach (var a in timepointDict[-1 * distinctPositionsInAscendingOrder[i]].iTHsalmon)
                    {
                        foreach (var b in timepointDict)
                        {
                            if (b.Key < salmonDict[a.Key].start && salmonDict[a.Key].end <= b.Key)
                            {
                                if (!timepointDict[b.Key].iTHsalmon.ContainsKey(a.Key))
                                {
                                    timepointDict[b.Key].iTHsalmon.Add(a.Key, 1); timepointDict[b.Key].salmonCount++;
                                }
                            }
                        }
                    }
                }
                timeLine[] fishesPerTPinAscendingOrder = timepointDict.Values.ToArray();
                Array.Sort(fishesPerTPinAscendingOrder, delegate (timeLine x, timeLine y) {
                    return y.salmonCount.CompareTo(x.salmonCount);
                });

                int salmonsCaught = 0;
                for (int i = 0; i < fishesPerTPinAscendingOrder.Length; i++)
                {
                    int tempSum = fishesPerTPinAscendingOrder[i].salmonCount +
                        maxFishesInUpdatedDictionary(fishesPerTPinAscendingOrder, fishesPerTPinAscendingOrder[i].iTHsalmon);
                    salmonsCaught = salmonsCaught < tempSum ? tempSum : salmonsCaught;
                }


                Console.WriteLine(salmonsCaught);
            }

            public static int maxFishesInUpdatedDictionary(timeLine[] originalCopy, Dictionary<int, int> exceptionList)
            {
                timeLine[] updatedCopy = new timeLine[originalCopy.Length];
                for (int i = 0; i < originalCopy.Length; i++)
                {
                    updatedCopy[i] = new timeLine(originalCopy[i].t,
                                                  originalCopy[i].iTHsalmon,
                                                  originalCopy[i].salmonCount);
                }
                //now  update the counts

                for (int i = 0; i < updatedCopy.Length; i++)
                {
                    foreach (var salmon in exceptionList)
                    {
                        if (updatedCopy[i].iTHsalmon.ContainsKey(salmon.Key))
                        {
                            updatedCopy[i].iTHsalmon.Remove(salmon.Key);
                            updatedCopy[i].salmonCount--;
                        }
                    }
                }

                //now findout the max
                Array.Sort(updatedCopy, delegate (timeLine x, timeLine y) {
                    return y.salmonCount.CompareTo(x.salmonCount);
                });

                return updatedCopy[0].salmonCount;
            }


        }
        public class Salmons
        {
            public int rollno;
            public int start;
            public int length;
            public int end;
            public Salmons(int r, int s, int l)
            {
                this.rollno = r;
                this.start = s;
                this.length = l;
                this.end = s - l;
            }
        }
        public class timeLine
        {
            public int t;
            public Dictionary<int, int> iTHsalmon = new Dictionary<int, int> { };
            public int salmonCount;
            public timeLine(int i, int sal, int c)
            {
                this.t = i;
                this.iTHsalmon.Add(sal, 1);
                this.salmonCount = c;
            }
            public timeLine(int i, Dictionary<int, int> sal, int c)
            {
                this.t = i;
                foreach (var pair in sal)
                {
                    this.iTHsalmon.Add(pair.Key, pair.Value);
                }
                this.salmonCount = c;
            }
        }
    }

}
