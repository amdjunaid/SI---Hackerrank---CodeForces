using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Hackerearth.CastHiringChallenge
{
    public class PerpendicularLines : ISolution
    {
        public override void Solve()
        {
            var t = ReadInt();
            while (t-- > 0)
            {
                try
                {
                    var line1 = ReadArrString().Select(long.Parse).ToArray();
                    var line2 = ReadArrString().Select(long.Parse).ToArray();

                    long ydist1 = line1[3] - line1[1];
                    long xdist1 = line1[2] - line1[0];
                    long ydist2 = line2[3] - line2[1];
                    long xdist2 = line2[2] - line2[0];

                    if (ydist1 == 0 || ydist2 == 0 || xdist1 == 0 || xdist2 == 0) {
                        output.AppendLine("INVALID");
                        continue;
                    }

                    BigInteger numeraterPt1 = new BigInteger(ydist1);
                    BigInteger numeraterPt2 = new BigInteger(ydist2);
                    BigInteger numerater = BigInteger.Multiply(numeraterPt1, numeraterPt2);

                    BigInteger denomPt1 = new BigInteger(xdist1);
                    BigInteger denomPt2 = new BigInteger(xdist2);
                    BigInteger denom = BigInteger.Multiply(denomPt1, denomPt2);
                    BigInteger rhs = BigInteger.Multiply(new BigInteger(-1), denom);

                    if (BigInteger.Compare(numerater,rhs)==0)
                    {
                        output.AppendLine("YES");
                    }
                    else
                    {
                        output.AppendLine("NO");
                    }
                }
                catch (DivideByZeroException)
                {
                    output.AppendLine("INVALID");
                    continue;
                }
            }
            Console.Write(output);
        }
    }
}
