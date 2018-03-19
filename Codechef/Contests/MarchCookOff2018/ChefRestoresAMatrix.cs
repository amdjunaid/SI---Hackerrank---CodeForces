using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchCookOff2018
{
    public class ChefRestoresAMatrix : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0)
            {
                var NandM = ReadArrString().Select(int.Parse).ToArray();
                var arr = new int[NandM[0]][];
                for (int i = 0; i < NandM[0]; i++)
                {
                    arr[i] = ReadArrString().Select(int.Parse).ToArray();
                }
                IsSolutionPossible(arr, NandM[0], NandM[1]);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void IsSolutionPossible(int[][] arr, int N, int M)
        {
            if (arr[0][0] == -1)
            {
                arr[0][0] = 1;
            }
            //first column
            for (int i = 1; i < N; i++)
            {
                if (arr[i][0] == -1)
                {
                    arr[i][0] = arr[i - 1][0];
                }
            }
            //first row
            for (int j = 1; j < M; j++)
            {
                if (arr[0][j] == -1)
                {
                    arr[0][j] = arr[0][j - 1];
                }
            }
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < M; j++)
                {
                    if (arr[i][j] == -1)
                    {
                        arr[i][j] = Math.Max(arr[i - 1][j], arr[i][j - 1]);
                    }
                }
            }
            bool isValidClosure = true;
            for (int j = 1; j < M; j++)
            {
                if (arr[0][j] < arr[0][j - 1])
                {
                    isValidClosure = false;
                    break;
                }
            }
            for (int i = 1; i < N; i++)
            {
                if (arr[i][0] < arr[i - 1][0])
                {
                    isValidClosure = false;
                    break;
                }
            }
            if (isValidClosure)
            {
                for (int i = 0; i < N; i++)
                {
                    isValidClosure = true;
                    for (int j = 0; j < M; j++)
                    {
                        if (!IsValidClosure(arr, i, j, N, M))
                        {
                            isValidClosure = false;
                            break;
                        }
                    }
                    if (!isValidClosure)
                        break;
                }
            }
            if (isValidClosure)
            {
                for (int i = 1; i < N; i++)
                {
                    for (int j = 1; j < M; j++)
                    {
                        output.Append(arr[i][j]);
                        if (j != M - 1)
                        {
                            output.Append(" ");
                        }
                    }
                    if (i != N - 1)
                    {
                        output.AppendLine();
                    }
                }
            }
            else
            {
                output.Append("-1");
            }
        }

        private bool IsValidClosure(int[][] arr, int i, int j, int N, int M)
        {
            if (arr[i][j] < arr[i - 1][j] || arr[i][j] < arr[i][j - 1])
            {
                return false;
            }
            return true;
        }
    }
}
