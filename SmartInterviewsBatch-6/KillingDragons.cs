using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class KillingDragons : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0)
            {
                var n = ReadInt();
                var energyToKill = ReadArrString().Select(short.Parse).ToArray();
                var energyInBowl = ReadArrString().Select(short.Parse).ToArray();
                output.AppendLine(FirstDungeon(energyToKill, energyInBowl).ToString());
            }
            Console.Write(output);
        }

        private int FirstDungeon(short[] energyToKill, short[] energyInBowl)
        {
            if (energyInBowl.Length == 1) {
                if (energyInBowl[0] < energyToKill[0])
                    return -1;
                else
                    return 1;
            }
            int startPt = 0, initialStartingPt = 0, i = 0, remainingEnergy = 0, noOfDungeons = energyToKill.Length;
            while (!((startPt == 0 && ((i % noOfDungeons) == noOfDungeons - 1)) || (((i % noOfDungeons) < startPt) && (startPt - (i % noOfDungeons) == 1))))
            {
                if (i / noOfDungeons > 2) {
                    break;
                }
                remainingEnergy += energyInBowl[i % noOfDungeons] - energyToKill[i % noOfDungeons];
                if (remainingEnergy < 0)
                {
                    startPt = (i + 1) % noOfDungeons;
                    remainingEnergy = 0;
                    if (initialStartingPt == 0 && (i / noOfDungeons == 0))
                    {
                        initialStartingPt = (i + 1) % noOfDungeons;
                    }
                }
                i++;
                if ((startPt == 0 && ((i % noOfDungeons) == noOfDungeons - 1)) || (((i % noOfDungeons) < startPt) && (startPt - (i % noOfDungeons) == 1)))
                {
                    remainingEnergy += energyInBowl[i%noOfDungeons] - energyToKill[i%noOfDungeons];
                }
            }
            if (remainingEnergy < 0)
                return -1;
            return startPt + 1;
        }
    }
}
