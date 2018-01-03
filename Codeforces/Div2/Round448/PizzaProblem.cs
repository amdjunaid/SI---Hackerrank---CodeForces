using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round448
{
    public class PizzaProblem :ISolution
    {
        public override void Solve()
        {
            short n = ReadShort();
            var arr = ReadArrString().Select(short.Parse).ToArray();
            Console.Write(MinimalDifferenceBtwnSectors(arr, n));
        }

        private int MinimalDifferenceBtwnSectors(short[] arr, short n)
        {
            Array.Sort(arr);
            short VasyaContainer = 0, PetyaContainer = 0;
            for (short j = (short)(arr.Length - 1); j >= 0; j--) {
                var prospectiveAdditionToVasya = arr[j] + VasyaContainer;
                var prospectiveAdditionToPetya = arr[j] + PetyaContainer;
                if (Math.Abs(prospectiveAdditionToVasya - PetyaContainer) >= Math.Abs(prospectiveAdditionToPetya - VasyaContainer))
                {
                    PetyaContainer += arr[j];
                }
                else {
                    VasyaContainer += arr[j];
                }
            }
            return Math.Abs(VasyaContainer - PetyaContainer);
        }
    }
}
