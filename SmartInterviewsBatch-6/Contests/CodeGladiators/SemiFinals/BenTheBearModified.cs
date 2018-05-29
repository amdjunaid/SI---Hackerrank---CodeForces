using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators.SemiFinals
{
    public class BenTheBearModified : ISolution
    {
        class Salmon
        {
            public int length { get; set; }
            public int time { get; set; }
            public HashSet<short> overlappingLi { get; set; }
        }

        Salmon[] salmonsArr = null;
        static int ans = int.MinValue;
        static Dictionary<int, HashSet<int>> dict;
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
                    length = lengthArr[i - 1],
                    time = timeArr[i - 1]
                };
            }

            PopulateNeighbours();

            FindMaxPair();

            Console.Write(ans);
        }

        private void FindMaxPair()
        {
            for (short i = 1; i < salmonsArr.Length; i++)
            {
                int localAns = !dict.ContainsKey(i) ? 1 : dict[i].Count + 1;
                int scndMax = 0;
                for (short j = 1; j < salmonsArr.Length; j++)
                {
                    if (j != i)
                    {
                        int jthCost = 1;
                        if (dict.ContainsKey(j)) {
                            jthCost = dict[j].Count + 1;
                            if (dict[j].Contains(i))
                                jthCost--;
                        }
                        //jthCost = !dict.ContainsKey(j) ? 1 : dict[j].Count + 1;
                        if (dict.ContainsKey(i))
                        {
                            if (!dict[i].Contains(j))
                            {
                                //if (jthCost != 1)
                                //{
                                //if (dict[j].Contains(i))
                                //    jthCost--;
                                if (dict.ContainsKey(j)) {
                                    var enumerater = dict[i].GetEnumerator();
                                    while (enumerater.MoveNext())
                                    {
                                        if (dict[j].Contains(enumerater.Current))
                                        {
                                            jthCost--;
                                        }
                                    }
                                }
                                //}
                            }
                            else
                                jthCost = 0;
                        }
                        scndMax = Math.Max(scndMax, jthCost);
                    }
                }
                ans = Math.Max(localAns + scndMax, ans);
            }
        }

        private void PopulateNeighbours()
        {
            dict = new Dictionary<int, HashSet<int>>();
            for (int i = 1; i < salmonsArr.Length; i++)
            {
                for (int j = 1; j < salmonsArr.Length; j++)
                {
                    if (i != j)
                    {
                        //if start point of jth salmon is within the time frame of ith salmon
                        if (salmonsArr[i].time >= salmonsArr[j].time && salmonsArr[i].time <= salmonsArr[j].length + salmonsArr[j].time)
                        {
                            if (dict.ContainsKey(i))
                            {
                                dict[i].Add(j);
                            }
                            else
                            {
                                dict.Add(i, new HashSet<int> { j });
                            }
                        }
                    }
                }
                int cnt = 1;
                if (dict.ContainsKey(i))
                {
                    cnt = dict[i].Count + 1;
                }
                ans = Math.Max(ans, cnt);
            }
        }
    }
}
