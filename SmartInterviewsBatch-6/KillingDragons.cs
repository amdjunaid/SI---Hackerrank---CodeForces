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
            int[] energyRemaining = new int[energyInBowl.Length];
            bool dearthExists = false;
            energyRemaining[0] = energyInBowl[0] - energyToKill[0];
            int sumBowl = energyInBowl[0], sumDragon = energyToKill[0], maximumDearthValue = energyRemaining[0], maximumDearthIndex = 0;
            for (int i = 1; i < energyInBowl.Length; i++)
            {
                sumBowl += energyInBowl[i];
                sumDragon += energyToKill[i];
                int currentRemainingEnergy = energyInBowl[i] - energyToKill[i];
                energyRemaining[i] = energyRemaining[i - 1] + currentRemainingEnergy;
                if (energyRemaining[i] < 0) {
                    dearthExists = true;
                }
                if (currentRemainingEnergy < 0)
                {
                    if (currentRemainingEnergy < maximumDearthValue)
                    {
                        maximumDearthValue = currentRemainingEnergy;
                        maximumDearthIndex = i;
                    }
                }
            }
            if (!dearthExists) {
                return 1;
            }
            if (sumBowl < sumDragon)
                return -1;
            int maximumOccuringPositive = 0, maximumOccuringPositiveIndex = maximumDearthIndex;
            for (int i = maximumDearthIndex; i < energyInBowl.Length; i++)
            {
                if (energyInBowl[i] - energyToKill[i] > maximumOccuringPositive)
                {
                    maximumOccuringPositive = energyInBowl[i] - energyToKill[i];
                    maximumOccuringPositiveIndex = i;
                }
            }
            energyRemaining[maximumOccuringPositiveIndex] = maximumOccuringPositive;
            for (int i = maximumOccuringPositiveIndex + 1; i < energyInBowl.Length; i++)
            {
                energyRemaining[i] = energyRemaining[i - 1] + energyInBowl[i] - energyToKill[i];
            }
            energyRemaining[0] = energyRemaining[energyRemaining.Length - 1] + energyInBowl[0] - energyToKill[0];
            for (int i = 1; i < maximumOccuringPositiveIndex; i++)
            {
                energyRemaining[i] = energyRemaining[i - 1] + energyInBowl[i] - energyToKill[i];
            }
            bool flag = true;
            for (int i = 0; i < energyRemaining.Length; i++)
            {
                if (energyRemaining[i] < 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag ? (maximumOccuringPositiveIndex + 1) : -1;
        }
    }
}
