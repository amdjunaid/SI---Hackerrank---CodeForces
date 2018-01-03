using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.GoodBye2017
{
    public class BuggyBot : ISolution
    {
        static char[][] maze = null;
        static List<string> permutations = new List<string>(24);
        byte isI = byte.MaxValue, isJ = byte.MaxValue, n, m;
        public override void Solve()
        {
            byte[] NandK = ReadArrString().Select(byte.Parse).ToArray();

            n = NandK[0];
            m = NandK[1];

            maze = new char[NandK[0]][];
            for (byte i = 0; i < NandK[0]; i++)
            {
                maze[i] = ReadString().ToCharArray();
                for (byte j = 0; j < NandK[1]; j++)
                {
                    if (maze[i][j] == 'S')
                    {
                        isI = i;
                        isJ = j;
                    }
                }
            }
            string instruction = ReadString();
            Console.Write(NoOfMappings(instruction));
        }

        private byte NoOfMappings(string instruction)
        {
            byte noOfMappings = 0;
            string positions = "0123";
            permute(positions, 0, 3);

            Dictionary<char, byte> map = new Dictionary<char, byte>();

            for (int i = 0; i < permutations.Count; i++)
            {
                string currentMappings = permutations[i];
                for (byte l = 0; l < currentMappings.Length; l++)
                {
                    if (map.ContainsKey(currentMappings[l]))
                    {
                        map[currentMappings[l]] = l;
                    }
                    else
                    {
                        map.Add(currentMappings[l], l);
                    }
                }
                byte j = isI, k = isJ;
                for (int x = 0; x < instruction.Length; x++)
                {
                    var direction = map[instruction[x]];
                    switch (direction)
                    {
                        case 0:
                            {
                                k--;
                                break;
                            }
                        case 1:
                            {
                                k++;
                                break;
                            }
                        case 2:
                            {
                                j--;
                                break;
                            }
                        case 3:
                            {
                                j++;
                                break;
                            }
                    }
                    if (j >= 0 && j < n && k >= 0 && k < m && maze[j][k] != '#')
                    {
                        if (maze[j][k] == 'E')
                        {
                            noOfMappings++;
                            break;
                        }
                        else
                            continue;
                    }
                    else
                        break;
                }
            }
            return noOfMappings;
        }

        private void permute(string str, int l, int r)
        {
            if (l == r)
                permutations.Add(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        public string swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = string.Empty;
            s += string.Join("", charArray);
            return s;
        }
    }
}
