using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Graphs
{
    public class NumberOfIslandsEasy : ISolution
    {
        static sbyte[] dx = new sbyte[] { -1, 0, 1, 0, -1, 1, 1, -1 };
        static sbyte[] dy = new sbyte[] { 0, 1, 0, -1, 1, 1, -1, -1 };
        static byte[][] matrix = null;
        static short R = 0, C = 0;
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                var RandC = ReadArrString().Select(short.Parse).ToArray();
                R = RandC[0];
                C = RandC[1];
                short NoOfIslands = 0;
                matrix = new byte[RandC[0]][];
                for (short i = 0; i < RandC[0]; i++)
                {
                    matrix[i] = ReadString().Select(x => Convert.ToByte(x)).ToArray();
                }
                for (short i = 0; i < RandC[0]; i++)
                {
                    for (short j = 0; j < RandC[1]; j++)
                    {
                        if (matrix[i][j] == 49)
                        {
                            NoOfIslands++;
                            DFS(i, j);
                        }
                    }
                }
                output.AppendLine(NoOfIslands.ToString());
            }
            Console.Write(output);
        }

        private void DFS(short i, short j)
        {
            if (i < 0 || i >= R || j < 0 || j >= C)
                return;
            if (matrix[i][j] == 49)//char representation of 1
            {
                matrix[i][j] = 48;//char representation of 0
                for (byte k = 0; k < 8; k++)
                {
                    DFS((short)(i + dx[k]), (short)(j + dy[k]));
                }
            }
        }
    }
}
