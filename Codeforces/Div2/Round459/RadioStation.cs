using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round459
{
    public class RadioStation : ISolution
    {
        public override void Solve()
        {
            var NandM = ReadArrString().Select(short.Parse).ToArray();
            Dictionary<string, string> dns = new Dictionary<string, string>();
            for (short i = 0; i < NandM[0]; i++)
            {
                var server = ReadArrString();
                dns.Add(server[1], server[0]);
            }
            for (short i = 0; i < NandM[1]; i++) {
                var command = ReadArrString();
                command[1] = command[1].Remove(command[1].Length - 1);
                output.AppendFormat("{0} {1}; #{2}", command[0], command[1], dns[command[1]]);
                output.AppendLine();
            }
            Console.Write(output);
        }
    }
}
