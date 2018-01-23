using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class PathInMatrix : ISolution
    {
        static int modulo = (int)1e9 + 7;
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                var NMB = ReadArrString().Select(int.Parse).ToArray();
                var matrix = new int[NMB[0], NMB[1]];
                for (int i = 0; i < NMB[2]; i++)
                {
                    var forbiddenIndex = ReadArrString().Select(int.Parse).ToArray();
                    matrix[forbiddenIndex[0], forbiddenIndex[1]] = -1;
                }
                output.AppendLine(NoOfWays(matrix, NMB[0], NMB[1]).ToString());
            }
            Console.Write(output);
        }

        private int NoOfWays(int[,] matrix, int N, int M)
        {
            sbyte[] dx = new sbyte[] { -1, -1, 0 };
            sbyte[] dy = new sbyte[] { 0, -1, -1 };
            matrix[0, 0] = 1;
            for (short j = 1; j < M; j++)
            {
                if (matrix[0, j] != -1)
                {
                    matrix[0, j] = matrix[0, j - 1] == -1 ? -1 : 1;
                }
            }
            for (short i = 1; i < N; i++)
            {
                if (matrix[i, 0] != -1)
                {
                    matrix[i, 0] = matrix[i - 1, 0] == -1 ? -1 : 1;
                }
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < M; j++)
                {
                    if (matrix[i, j] != -1)
                    {
                        for (byte k = 0; k < 3; k++)
                        {
                            matrix[i, j] = (matrix[i, j] + (matrix[i + dx[k], j + dy[k]] == -1 ? 0 : matrix[i + dx[k], j + dy[k]])) % modulo;
                        }
                    }
                }
            }
            return matrix[N - 1, M - 1] == -1 ? 0 : matrix[N - 1, M - 1];
        }
    }
}
