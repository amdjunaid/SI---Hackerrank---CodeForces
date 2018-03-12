using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Graphs
{
    public class Forest : ISolution
    {
        static Dictionary<int, HashSet<int>> graph = null;
        static bool[] visited = null;
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                var NandM = ReadArrString().Select(int.Parse).ToArray();
                graph = new Dictionary<int, HashSet<int>>();
                visited = new bool[NandM[0] + 1];
                int noOfConnectedComponents = 0;
                AddEdges(NandM[1]);
                for (short i = 1; i <= NandM[0]; i++)
                {
                    if (!visited[i])
                    {
                        noOfConnectedComponents++;
                        DFS(i);
                    }
                }
                if (noOfConnectedComponents == 1 && (NandM[1] == NandM[0] - 1))
                {
                    output.AppendLine("Yes");
                }
                else if (noOfConnectedComponents > 1 && !(NandM[1] == NandM[0] - 1)) {
                    output.AppendLine("Yes");
                }
                else
                {
                    output.AppendLine("No");
                }
            }
            Console.Write(output);
        }

        private void DFS(int i)
        {
            if (!visited[i])
            {
                visited[i] = true;
                if (graph.ContainsKey(i))
                {
                    var enumerator = graph[i].GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DFS(enumerator.Current);
                    }
                }
            }
        }

        public void AddEdges(int M)
        {
            for (int i = 0; i < M; i++)
            {
                var UandV = ReadArrString().Select(int.Parse).ToArray();
                if (graph.ContainsKey(UandV[0]))
                {
                    graph[UandV[0]].Add(UandV[1]);
                }
                else
                {
                    graph.Add(UandV[0], new HashSet<int> { UandV[1] });
                }
                if (graph.ContainsKey(UandV[1]))
                {
                    graph[UandV[1]].Add(UandV[0]);
                }
                else
                {
                    graph.Add(UandV[1], new HashSet<int> { UandV[0] });
                }
            }
        }
    }
}
