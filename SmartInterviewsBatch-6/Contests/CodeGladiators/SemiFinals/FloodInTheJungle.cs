using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators.SemiFinals
{
    public class FloodInTheJungle : ISolution
    {
        class Node
        {
            public int Id { get; set; }
            public int InVertex { get; set; }
            public int OutVertex { get; set; }
            public int MonkeyCnt { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Threshold { get; set; }
        }

        public static int V = 0;
        public static int[,] twodGraph = null;
        static Node[] graph = null;
        public override void Solve()
        {
            //var NandC = ReadArrString().Select(int.Parse).ToArray();
            var NandC1 = ReadArrString();
            var NandC = new int[1];
            NandC[0] = int.Parse(NandC1[0]);
            V = NandC[0] * 2 + 1;
            graph = new Node[NandC[0]];
            twodGraph = new int[NandC[0] * 2 + 1, NandC[0] * 2 + 1];
            int totalMonkeyCnt = 0;
            for (int i = 0; i < NandC[0]; i++)
            {
                var info = ReadArrString().Select(int.Parse).ToArray();
                totalMonkeyCnt += info[2];
                graph[i] = new Node
                {
                    Id = i,
                    X = info[0],
                    Y = info[1],
                    OutVertex = i,
                    MonkeyCnt = info[2],
                    Threshold = info[3]
                };
            }

            for (int i = 0; i < NandC[0]; i++)
            {
                for (int j = 0; j < NandC[0]; j++)
                {
                    if (i != j)
                    {
                        double ydist = Math.Abs(graph[j].Y - graph[i].Y);
                        ydist *= ydist;
                        double xdist = Math.Abs(graph[j].X - graph[i].X);
                        xdist *= xdist;
                        double dist = Math.Ceiling(Math.Sqrt(ydist + xdist));
                        //out vertex to out vertex
                        if (dist <= Convert.ToDouble(NandC1[1]))
                        {
                            twodGraph[i, j] = graph[i].Threshold;
                            twodGraph[j, i] = graph[j].Threshold;
                        }
                        //in vertex to out vertex
                        twodGraph[NandC[0] + i, i] = graph[i].MonkeyCnt;
                        twodGraph[NandC[0] + j, j] = graph[j].MonkeyCnt;
                    }
                    twodGraph[NandC[0] * 2, NandC[0] + j] = int.MaxValue;
                }
            }

            Check(NandC[0], totalMonkeyCnt);
            Console.Write(output);
        }

        private void Check(int N, int totalMonkeyCnt)
        {
            int totalMeetingPts = 0;
            //end point
            for (int i = 0; i < N; i++)
            {
                //start point
                //for (int j = 0; j < N; j++)
                //{
                //    //if (i != j)
                //    //{
                //        twodGraph[N * 2, N + j] = int.MaxValue;
                //    //}
                //}
                int maxCost = fordFulkerson(twodGraph, N * 2, i);
                if (totalMonkeyCnt == maxCost) {
                    totalMeetingPts++;
                    output.Append(i + " ");
                }
            }
            if (totalMeetingPts == 0)
                output.Append("-1");
        }

        private bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            // Create a visited array and mark all vertices as not visited
            bool[] visited = new bool[V];

            // Create a queue, enqueue source vertex and mark source vertex
            // as visited
            Queue<int> q = new Queue<int>(V);
            q.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (!q.IsEmpty())
            {
                int u = q.Peek();
                q.Dequeue();

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false && rGraph[u, v] > 0)
                    {
                        q.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            // If we reached sink in BFS starting from source, then return
            // true, else false
            return (visited[t] == true);
        }

        private int fordFulkerson(int[,] graph, int s, int t)
        {
            int u, v;

            // Create a residual graph and fill the residual graph with
            // given capacities in the original graph as residual capacities
            // in residual graph
            int[,] rGraph = new int[V, V]; // Residual graph where rGraph[i][j] indicates 
                                           // residual capacity of edge from i to j (if there
                                           // is an edge. If rGraph[i][j] is 0, then there is not)  
            for (u = 0; u < V; u++)
                for (v = 0; v < V-1; v++)
                    rGraph[u, v] = graph[u, v];

            int[] parent = new int[V];  // This array is filled by BFS and to store path

            int max_flow = 0;  // There is no flow initially

            // Augment the flow while tere is path from source to sink
            while (bfs(rGraph, s, t, parent))
            {
                // Find minimum residual capacity of the edges along the
                // path filled by BFS. Or we can say find the maximum flow
                // through the path found.
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                // update residual capacities of the edges and reverse edges
                // along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;
            }

            // Return the overall flow
            return max_flow;
        }
    }
}
