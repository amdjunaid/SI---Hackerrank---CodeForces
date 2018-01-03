using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class InterleaveModified
    {
        static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        static Func<byte> ReadByte = () => byte.Parse(Console.ReadLine().Trim());
        static Func<string> ReadString = () => Console.ReadLine().Trim();

        static StringBuilder output = new StringBuilder();
        static List<string> ListOfInterLeavedStrings = null;
        public static void Solve() {
            byte t = ReadByte();
            for (byte i = 0; i < t; i++) {
                var AandB = ReadString().Split(' ').ToArray();
                ListOfInterLeavedStrings = new List<string>();
                output.AppendLine("Case #" + (i + 1) + ":");
                GenerateInterLeavedString(AandB[0], AandB[1], 0, 0);
                Array.Sort(ListOfInterLeavedStrings.ToArray(), delegate (string x, string y)
                {
                    for (int j = 0; j < x.Length; j++)
                    {
                        if (x[j].CompareTo(y[j]).Equals(0))
                            continue;
                        return x[j].CompareTo(y[j]);
                    }
                    return x.CompareTo(y);
                });
                Array.Reverse(ListOfInterLeavedStrings.ToArray());
                output.AppendLine(string.Join(Environment.NewLine, ListOfInterLeavedStrings));
            }
            Console.Write(output);
        }

        public static void GenerateInterLeavedString(string A, string B, int AIndex, int BIndex) {
            for (int i = AIndex; i <= A.Length; i++) {
                    string prospectiveInterleavedString = A.Substring(0, i) + B[BIndex] + (i != A.Length ? A.Substring(i) : null);
                    if ((B.Length -BIndex)!=1)
                    {
                        GenerateInterLeavedString(prospectiveInterleavedString, B, i + 1, BIndex + 1);
                    }
                    else {
                        ListOfInterLeavedStrings.Add(prospectiveInterleavedString);
                    }
            }
        }
    }
}
