using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._13
{
    public class Dubstep : ISolution
    {
        public override void Solve()
        {
            var step = ReadString();
            var output = string.Join(" ", step.Split(new string[] { "WUB" }, StringSplitOptions.RemoveEmptyEntries));
            Console.Write(output);
        }
    }
}
