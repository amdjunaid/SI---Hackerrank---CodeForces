using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerearth.CastHiringChallenge
{
    public class BlackAndWhite : ISolution
    {
        static bool[] visited;
        public class Node
        {
            public int white { get; set; }
            public int black { get; set; }
            public long weight { get; set; }
        }

        public override void Solve()
        {
            var NandM = ReadArrString().Select(int.Parse).ToArray();
            visited = new bool[NandM[0] + 1];
            var computed = new bool[NandM[0] + 1];
            var arr = new Node[NandM[0] + 1];
            var graph = new int[NandM[0] + 1, NandM[0] + 1];

            Dictionary<int, HashSet<int>> parent = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < NandM[1]; i++)
            {
                var edge = ReadArrString().Select(int.Parse).ToArray();
                graph[edge[0], edge[1]] = edge[2];

                if (parent.ContainsKey(edge[1]))
                {
                    parent[edge[1]].Add(edge[0]);
                }
                else
                {
                    parent.Add(edge[1], new HashSet<int> { edge[0] });
                }
            }

            byte[] colors = ReadArrString().Select(byte.Parse).ToArray();

            for (int i = 1; i <= NandM[0]; i++)
            {
                arr[i] = new Node
                {
                    black = colors[i - 1] == 1 ? 0 : 1,
                    white = colors[i - 1] == 1 ? 1 : 0,
                    weight = 0
                };
            }



            Dictionary<int, List<Node>> map = new Dictionary<int, List<Node>>();

            DFS(NandM[0], NandM[0], parent, graph, visited, map, computed, arr);

            long ans = long.MaxValue;

            if (!map.ContainsKey(NandM[0]))
            {
                Console.Write("-1");
            }
            else
            {
                for (int i = 0; i < map[NandM[0]].Count; i++)
                {
                    var option = map[NandM[0]][i];
                    if (Math.Abs(option.white - option.black) <= 1)
                    {
                        ans = Math.Min(ans, option.weight);
                    }
                }
                Console.Write(ans != long.MaxValue ? ans : -1);
            }
        }

        public void DFS(int i, int N, Dictionary<int, HashSet<int>> parent, int[,] graph, bool[] visited, Dictionary<int, List<Node>> options, bool[] computed, Node[] arr)
        {
            if (i == 1)
            {
                if (!options.ContainsKey(1))
                {
                    options.Add(1, new List<Node> { new Node {
                        black = arr[i].black,
                        white = arr[i].white
                    } });
                    computed[1] = true;
                }
                return;
            }
            if (parent.ContainsKey(i))
            {
                var enumerater = parent[i].GetEnumerator();
                while (enumerater.MoveNext())
                {
                    int j = enumerater.Current;
                    if (graph[j, i] != 0 && !visited[j])
                    {
                        visited[j] = true;
                        DFS(j, N, parent, graph, visited, options, computed, arr);
                        computed[j] = true;
                        if (!options.ContainsKey(i))
                            options.Add(i, new List<Node>());
                        var jOptions = options.ContainsKey(j) ? options[j] : new List<Node>();
                        for (int k = 0; k < jOptions.Count; k++)
                        {
                            var node = new Node
                            {
                                black = jOptions[k].black + arr[i].black,
                                white = jOptions[k].white + arr[i].white,
                                weight = jOptions[k].weight + graph[j, i]
                            };
                            options[i].Add(node);
                        }
                    }
                    else if (graph[j, i] != 0 && computed[j])
                    {
                        var jOptions = options.ContainsKey(j) ? options[j] : new List<Node>();
                        if (!options.ContainsKey(i))
                            options.Add(i, new List<Node>());
                        for (int k = 0; k < jOptions.Count; k++)
                        {
                            var node = new Node
                            {
                                black = jOptions[k].black + arr[i].black,
                                white = jOptions[k].white + arr[i].white,
                                weight = jOptions[k].weight + graph[j, i]
                            };
                            options[i].Add(node);
                        }
                    }
                }
            }
        }
    }
}
