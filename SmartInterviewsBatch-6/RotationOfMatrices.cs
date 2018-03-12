using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class RotationOfMatrices : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0) {
                byte N = ReadByte();
                byte[][] arr = new byte[N][];
                for (byte i = 0; i < N; i++) {
                    arr[i] = ReadArrString().Select(byte.Parse).ToArray();
                }
                
            }
        }
    }
}
