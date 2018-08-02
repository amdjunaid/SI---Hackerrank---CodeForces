using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techgig.Finale2018
{
    public class Problem2 : ISolution
    {
        class Hill
        {
            public int TSpeed { get; set; }
            public int HSpeed { get; set; }
            public int Cost { get; set; }
        }

        class Costs
        {
            public long MarginalCost { get; set; }
            public int NoOfRoads { get; set; }
            public long Dist { get; set; }
        }

        static bool[] hill = null;
        static Hill[,] matrix = null;
        static int[,] graph = null;
        static int V = 0;
        public override void Solve()
        {
            var NandM = ReadArrString().Select(int.Parse).ToArray();
            V = NandM[0] + 1;

            matrix = new Hill[NandM[0] + 1, NandM[0] + 1];
            graph = new int[NandM[0] + 1, NandM[0] + 1];
            hill = new bool[NandM[0] + 1];

            for (int i = 1; i < V; i++) {
                for (int j = 1; j < V; j++) {
                    matrix[i, j] = new Hill();
                }
            }

            for (int i = 0; i < NandM[1]; i++)
            {
                var hillInfo = ReadArrString().Select(int.Parse).ToArray();
                matrix[hillInfo[0], hillInfo[0]].Cost = int.MaxValue;

                if (hillInfo[2] < hillInfo[3])
                {
                    matrix[hillInfo[0], hillInfo[1]].TSpeed = hillInfo[2];
                    matrix[hillInfo[0], hillInfo[1]].HSpeed = hillInfo[3];
                    hill[hillInfo[0]] = true;
                    graph[hillInfo[0], hillInfo[1]] = hillInfo[2];
                }
            }
            path();
        }

        public void path()
        {
            long ans = long.MaxValue, minNoOfRoads = 0;
            var costs = floydWarshall(graph);
            for (int i = 1; i < V; i++)
            {
                if (hill[i])
                {
                    long maxPerHill = long.MaxValue, noOfRoads = 0;
                    //cost from i to its immediate neighbours j + path from j to i
                    //if max, then update with global max

                    for (int j = 1; j < V; j++)
                    {
                        if (costs[i, j].Dist + costs[j, i].Dist < maxPerHill)
                        {
                            maxPerHill = costs[i, j].Dist + costs[j, i].Dist;
                            noOfRoads = costs[i, j].NoOfRoads + costs[j, i].NoOfRoads;
                        }
                    }
                    if (ans > maxPerHill)
                    {
                        ans = maxPerHill;
                        minNoOfRoads = noOfRoads;
                    }
                    else if (ans == maxPerHill)
                    {
                        minNoOfRoads = noOfRoads;
                    }
                }
            }
            Console.Write(ans + " " + minNoOfRoads);
        }

        Costs[,] floydWarshall(int[,] graph)
        {
            /* dist[][] will be the output matrix that will finally have the shortest 
              distances between every pair of vertices */
            int i, j, k;
            //long[,] dist = new long[V, V];
            Costs[,] abstractDists = new Costs[V, V];

            /* Initialize the solution matrix same as input graph matrix. Or 
               we can say the initial values of shortest distances are based
               on shortest paths considering no intermediate vertex. */
            for (i = 1; i < V; i++)
                for (j = 1; j < V; j++)
                    abstractDists[i, j] = new Costs
                    {
                        Dist = graph[i, j]
                    };

            /* Add all vertices one by one to the set of intermediate vertices.
              ---> Before start of an iteration, we have shortest distances between all
              pairs of vertices such that the shortest distances consider only the
              vertices in set {0, 1, 2, .. k-1} as intermediate vertices.
              ----> After the end of an iteration, vertex no. k is added to the set of
              intermediate vertices and the set becomes {0, 1, 2, .. k} */
            for (k = 1; k < V; k++)
            {
                // Pick all vertices as source one by one
                for (i = 1; i < V; i++)
                {
                    // Pick all vertices as destination for the
                    // above picked source
                    for (j = 1; j < V; j++)
                    {
                        // If vertex k is on the shortest path from
                        // i to j, then update the value of dist[i][j]
                        if (abstractDists[i, k].Dist + abstractDists[k, j].Dist < abstractDists[i, j].Dist)
                        {
                            abstractDists[i, j].Dist = abstractDists[i, k].Dist + abstractDists[k, j].Dist;
                            abstractDists[i, j].MarginalCost = matrix[i, k].HSpeed + matrix[k, j].HSpeed - matrix[i, k].TSpeed - matrix[i, k].TSpeed;
                            abstractDists[i, j].NoOfRoads += 2;
                        }
                        else
                        {
                            abstractDists[i, j].NoOfRoads += 1;
                        }
                    }
                }
            }

            return abstractDists;
        }
    }
}
