using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class CollectingApples : ISolution
    {
        static short[,] dp = null;
        static short[][] maze = null;
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                var NandM = ReadArrString().Select(short.Parse).ToArray();
                dp = new short[NandM[0], NandM[1]];
                maze = new short[NandM[0]][];
                for (int i = 0; i < NandM[0]; i++)
                {
                    maze[i] = ReadArrString().Select(short.Parse).ToArray();
                }
                output.AppendLine(ComputeMaxApplesCollected(NandM[0], NandM[1]).ToString());
            }
            Console.Write(output);
        }

        private short ComputeMaxApplesCollected(short N, short M)
        {
            short i = 0, j = 0;
            dp[0, 0] = maze[0][0];
            for (j = 1; j < M; j++)
            {
                dp[0, j] = (short)(dp[0, j - 1] + maze[0][j]);
            }
            j = 0;
            for (i = 1; i < N; i++)
            {
                dp[i, 0] = (short)(dp[i - 1, j] + maze[i][0]);
            }

            for (i = 1; i < N; i++)
            {
                for (j = 1; j < M; j++)
                {
                    dp[i, j] = (short)(Math.Max(dp[i, j - 1], dp[i - 1, j]) + maze[i][j]);
                }
            }
            return dp[N - 1, M - 1];
        }

        /// <summary>
        /// dp state: which path from current position gives the max number of apples + no of apples at current position
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        private short ComputeMaxApplesCollectedModified(short N, short M)
        {
            short i, j;
            dp[N - 1, M - 1] = maze[N - 1][M - 1];
            for (j = (short)(M - 1); j >= 0; j--)
            {
                dp[N - 1, j] = (short)(dp[N - 1, j - 1] + maze[N - 1][j]);
            }
            for (i = (short)(N-1); i >=0; i--)
            {
                dp[i, M-1] = (short)(dp[i - 1, M-1] + maze[i][M-1]);
            }

            for (i = (short)(N-2); i >=0 ; i--)
            {
                for (j = (short)(M-2); j >=0; j--)
                {
                    dp[i, j] = (short)(Math.Max(dp[i, j + 1], dp[i + 1, j]) + maze[i][j]);
                }
            }
            return dp[0, 0];
        }
    }
}
