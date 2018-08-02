using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techgig.Practise.FloodFill
{
    public class ArthosParthos : ISolution
    {
        static byte r, c;
        static char[][] matrix = null;
        public override void Solve()
        {
            var t = ReadSByte();
            while (t-- > 0)
            {
                r = ReadByte();
                c = ReadByte();
                var coordinates = ReadArrString().Select(byte.Parse).ToArray();
                matrix = new char[r][];
                for (int i = 0; i < r; i++)
                {
                    matrix[i] = ReadArrString().Select(char.Parse).ToArray();
                }
                FloodFill(coordinates[0], coordinates[1]);
                output.AppendLine(matrix[coordinates[2]][coordinates[3]] == 'S' ? "YES" : "NO");
            }
            Console.Write(output);
        }

        /// <summary>
        /// convert target color to 's' color
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        public void FloodFill(byte sr, byte sc)
        {
            var dx = new sbyte[] { -1, 0, 1, 0 };
            var dy = new sbyte[] { 0, 1, 0, -1 };
            Stack<Tuple<byte, byte>> stack = new Stack<Tuple<byte, byte>>();
            stack.Push(new Tuple<byte, byte>(sr, sc));
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                matrix[node.Item1][node.Item2] = 'S';
                for (byte k = 0; k < 4; k++)
                {
                    if (Check_Avail((byte)(node.Item1 + dx[k]), (byte)(node.Item2 + dy[k])))
                    {
                        stack.Push(new Tuple<byte, byte>((byte)(node.Item1 + dx[k]), (byte)(node.Item2 + dy[k])));
                    }
                }
            }
        }

        private bool Check_Avail(byte x, byte y)
        {
            if (x >= 0 && x <= r-1 && y >= 0 && y <= c-1)
            {
                return matrix[x][y] == '.' ? true : false;
            }
            return false;
        }
    }
}
