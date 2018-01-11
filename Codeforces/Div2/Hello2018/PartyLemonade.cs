using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Hello2018
{
    public class PartyLemonade : ISolution
    {
        public class BottleType
        {
            public int Volume { get; set; }
            public int Cost { get; set; }
        }


        public override void Solve()
        {
            var NandL = ReadArrString().Select(int.Parse).ToArray();
            var costs = ReadArrString().Select(int.Parse).ToArray();
            BottleType[] bottles = new BottleType[costs.Length];
            for (int i = 1; i <= costs.Length; i++)
            {
                bottles[i - 1] = new BottleType
                {
                    Volume = (int)Math.Pow(2, i - 1),
                    Cost = costs[i - 1]
                };
            }
            Console.Write(MinPossibleCost(bottles, NandL[1]).ToString());
        }

        private static int MinPossibleCost(BottleType[] elements, int L)
        {
            int n = 1 << elements.Length, minPossibleCost = int.MaxValue;
            if (elements[0].Volume >= L)
            {
                minPossibleCost = elements[0].Cost;
            }

            for (int i = 2; i < n; i++)
            {
                int possibleVolumeCollection = 0, costIncurred = 0;
                int sizeoFCurrentSubset = (int)Math.Floor(Math.Log(i, 2));
                for (int j = 0; j <= sizeoFCurrentSubset; j++)
                {
                    if ((i & (1 << j)) != 0) // if jth Bit in ith Number is set or not
                    {
                        possibleVolumeCollection += elements[j].Volume;
                        costIncurred += elements[j].Cost;
                    }
                }
                if (possibleVolumeCollection >= L && costIncurred < minPossibleCost)
                {
                    minPossibleCost = costIncurred;
                }
            }
            return minPossibleCost;
        }
    }


}
