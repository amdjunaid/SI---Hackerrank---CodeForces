using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round476
{
    public class PaperAirplanes : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToArray();
            var noOfSheetsPerPerson = (int)System.Math.Ceiling((double)arr[1] / arr[2]);
            var noOfPacksRequired = (int)Math.Ceiling((double)(noOfSheetsPerPerson * arr[0]) / arr[3]);
            Console.Write(noOfPacksRequired);
        }
    }
}
