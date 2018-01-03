using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class TOH
    {
        public static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        public static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        public static Func<string> ReadString = () => Console.ReadLine().Trim();
        static StringBuilder moves = new StringBuilder();
        static StringBuilder totalMovesForT = new StringBuilder();
        static short minSteps = 0;
        public static void Solve()
        {
            byte t = Convert.ToByte(ReadString());
            while (t-- > 0)
            {
                byte n = Convert.ToByte(ReadString());
                minSteps = 0;
                TowerOfHanoi(n, 'A', 'C', 'B');
                totalMovesForT.AppendLine(minSteps.ToString());
                totalMovesForT.Append(moves);
                moves = new StringBuilder();
            }
            Console.Write(totalMovesForT);
            totalMovesForT = null;
            moves = null;
        }

        public static void TowerOfHanoi(byte n, char src, char dst, char tmp)
        {
            if (n == 0) return;
            //move n-1 disks from A to B using C in the first call to this recursive function.
            TowerOfHanoi((byte)(n - 1), src, tmp, dst);
            string message = string.Format("Move {0} from {1} to {2}", n, src, dst);
            minSteps++;
            moves.AppendLine(message);
            //move n-1 disks from B to C using A after moving Nth Disk from A to C in the above move statement: consider the scenario that the call has occurred.
            TowerOfHanoi((byte)(n - 1), tmp, dst, src);
        }
    }
}
