using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Graphs
{
    public class PathInAGraph : ISolution
    {
        static bool[] visited = null;
        static Dictionary<byte, HashSet<byte>> graph = null;
        public override void Solve()
        {
            short t = ReadShort();
            for (short j = 1; j <= t; j++)
            {
                var NandM = ReadArrString().Select(byte.Parse).ToArray();
                graph = new Dictionary<byte, HashSet<byte>>();
                for (byte i = 0; i < NandM[1]; i++)
                {
                    var UandV = ReadArrString().Select(byte.Parse).ToArray();
                    if (graph.ContainsKey(UandV[0]))
                    {
                        graph[UandV[0]].Add(UandV[1]);
                    }
                    else
                    {
                        graph.Add(UandV[0], new HashSet<byte> { UandV[1] });
                    }
                    if (graph.ContainsKey(UandV[1]))
                    {
                        graph[UandV[1]].Add(UandV[0]);
                    }
                    else
                    {
                        graph.Add(UandV[1], new HashSet<byte> { UandV[0] });
                    }
                }
                var Q = ReadByte();
                output.AppendLine("Test Case #" + j + ":");
                for (byte i = 0; i < Q; i++)
                {
                    visited = new bool[NandM[0] + 1];
                    var SrcAndDst = ReadArrString().Select(byte.Parse).ToArray();
                    output.AppendLine(DoesPathExist(SrcAndDst[0], SrcAndDst[1], NandM[0]) ? "Yes" : "No");
                }
            }
            Console.Write(output);
        }

        private bool DoesPathExist(byte u, byte v, byte N)
        {
            if (u == v)
                return true;
            System.Collections.Generic.Queue<byte> que = new System.Collections.Generic.Queue<byte>(N);
            que.Enqueue(u);
            while (que.Count() != 0)
            {
                byte curr = que.Dequeue();
                if (curr == v)
                    return true;
                if (graph.ContainsKey(curr))
                {
                    if (graph[curr].Contains(v))
                        return true;
                }
                if (graph.ContainsKey(v))
                {
                    if (graph[v].Contains(curr))
                        return true;
                }
                if (!visited[curr])
                {
                    visited[curr] = true;
                    if (graph.ContainsKey(curr))
                    {
                        var enumerator = graph[curr].GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            que.Enqueue(enumerator.Current);
                        }
                    }
                }
            }
            return false;
        }
    }
}
