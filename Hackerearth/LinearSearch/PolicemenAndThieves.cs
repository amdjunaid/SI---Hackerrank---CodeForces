using System;
using System.Linq;

namespace Hackerearth.LinearSearch
{
    public class PolicemenAndThieves : ISolution
    {
        private static int HowManyTheivesCanBeCaught(char[][] A, int K)
        {
            short NoOfTheivesCaught = 0;
            short N = (short)A.Length;
            //for each row
            for (short i = 0; i < N; i++)
            {
                for (short j = 0; j < N; j++) {
                    if (A[i][j] == 'T')
                    {
                        for (int T = j + 1; T <= K + j; T++)
                        {
                            if (T >= A[i].Length)
                            {
                                break;
                            }
                            if (A[i][T] == 'P')
                            {
                                NoOfTheivesCaught += 1;
                                A[i][j] = 'C';
                                A[i][T] = 'C';
                                break;
                            }
                        }
                    }
                    else if (A[i][j] == 'P')
                    {
                        for (int T = j + 1; T <= K + j; T++)
                        {
                            if (T >= A[i].Length)
                            {
                                break;
                            }
                            if (A[i][T] == 'T')
                            {
                                NoOfTheivesCaught += 1;
                                A[i][j] = 'C';
                                A[i][T] = 'C';
                                break;
                            }
                        }
                    }
                }
            }
            return NoOfTheivesCaught;
        }

        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                int[] NandK = ReadArrString().Select(x => int.Parse(x)).ToArray();
                char[][] arr = new char[NandK[0]][];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = ReadArrString().Select(x => char.Parse(x)).ToArray();
                }
                output.AppendLine(HowManyTheivesCanBeCaught(arr, NandK[1]).ToString());
            }
            Console.Write(output);
        }
    }
}
