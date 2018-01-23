using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class ActivitySelection : ISolution
    {
        class Activity {
            public int startTime { get; set; }
            public int finishTime { get; set; }
        }
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                short n = ReadShort();
                var s = ReadArrString().Select(int.Parse).ToArray();
                var f = ReadArrString().Select(int.Parse).ToArray();
                var activities = new Activity[s.Length];
                for (int i = 0; i < s.Length; i++) {
                    activities[i] = new Activity {
                        startTime = s[i],
                        finishTime = f[i]
                    };
                }
                Array.Sort(activities, delegate (Activity x, Activity y) {
                    return x.finishTime.CompareTo(y.finishTime);
                });

                short maxNonOccuringActivities = 1;
                int k = 0;
                for (int i = 1; i < s.Length; i++) {
                    if (activities[i].startTime >= activities[k].finishTime) {
                        maxNonOccuringActivities++;
                        k = i;
                    }
                }
                output.AppendLine(maxNonOccuringActivities.ToString());
            }
            Console.Write(output);
        }
    }
}
