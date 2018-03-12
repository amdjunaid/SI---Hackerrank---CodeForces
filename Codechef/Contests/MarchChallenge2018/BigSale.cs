using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchChallenge2018
{
    public class BigSale : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0)
            {
                var n = ReadInt();
                double loss = 0;
                while (n-- > 0)
                {
                    var PandQandD = ReadArrString().Select(byte.Parse).ToArray();
                    loss += TotalLossIncurred(PandQandD[0], PandQandD[1], PandQandD[2]);
                }
                output.AppendLine(loss.ToString());
            }
            Console.Write(output);
        }

        private double TotalLossIncurred(byte price, byte quantity, double discount)
        {
            double increasedPrice = (1 + discount / 100) * price;
            double discountedPrice = increasedPrice - increasedPrice * discount / 100;
            return (price - discountedPrice) * quantity;
        }
    }
}
