using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round457
{
    public class JamieAndAlarmSnooze : ISolution
    {
        public override void Solve()
        {
            byte x = ReadByte();
            var HHMM = ReadArrString().Select(sbyte.Parse).ToArray();
            Console.Write(MinNoOfSnooze(x, HHMM[0], HHMM[1]));
        }

        private long MinNoOfSnooze(byte x, sbyte hhZ, sbyte mmZ)
        {
            if (hhZ.ToString().Contains("7") || mmZ.ToString().Contains("7"))
            {
                return 0;
            }
            sbyte hhY = hhZ, mmY = mmZ;
            int noOfDays = 0;
            while (true)
            {
                for (int h = hhY; h >= 0; h--)
                {
                    for (int m = mmY; m >= 0; m--)
                    {
                        if (h.ToString().Contains("7") || m.ToString().Contains("7"))
                        {
                            // add minutes from noOfDays passed + cover up difference in minutes of one of the previous hours + for remaining hours, multiply minutes * diff -1 of hours
                            // to get all the minutes added till current hour. now, from here add previous minutes to current minute and substract from wake up minute.

                            //long differenceTime = 24 * 60 * noOfDays + (hhZ == h ? 0 : (60 - mmZ - 1)) + (Math.Abs(hhZ - h) - (hhZ != h ? -1 : 0)) * (60) + mmZ - m;
                            long differenceTime = 24 * 60 * noOfDays + (hhZ == h ? 0 : (60 - m - 1)) + (Math.Abs(hhZ - h) - (hhZ != h ? 1 : 0)) * (60) + Math.Abs(hhZ == h ? m - mmZ : (60 - m - 1) + mmZ + 1);
                            if (differenceTime % x == 0)
                            {
                                return differenceTime / x;
                            }
                        }
                    }
                    mmY = 59;
                }
                hhY = 23;
                noOfDays++;
            }
        }
    }
}
