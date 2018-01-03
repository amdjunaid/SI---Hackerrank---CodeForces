using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6b
{
    public class GameOfSquares : ISolution
    {
        static bool[] Wins = new bool[(int)1e5 + 1];
        public override void Solve()
        {
            int t = ReadInt();
            Precompute();
            while (t-- > 0)
            {
                int n = ReadInt();
                output.AppendLine(Wins[n] ? "Win" : "Lose");
            }
            Console.Write(output);
        }

        private void Precompute()
        {
            Wins[1] = true;
            for (int i = 2; i < Wins.Length; i++)
            {
                int perfectSquaresLimit = (int)Math.Floor(Math.Sqrt(i));
                bool DoesOptimizedStepExist = false;
                for (int idx = 1; idx <= perfectSquaresLimit; idx++)
                {
                    long square = (long)idx * idx;
                    if (square == i)
                    {
                        DoesOptimizedStepExist = true;
                        break;
                    }
                    else if (!Wins[i - square])
                    {
                        DoesOptimizedStepExist = true;
                        break;
                    }
                }
                if (DoesOptimizedStepExist)
                {
                    Wins[i] = true;
                }
            }
        }
    }
}
