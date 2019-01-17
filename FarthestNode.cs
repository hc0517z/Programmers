using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Programmers
{
//    n	vertex	return
//    6	[[3, 6], [4, 3], [3, 2], [1, 3], [1, 2], [2, 4], [5, 2]]	3
    public static class TestFarthestNode
    {
        public static void Run()
        {
            var instance = new FarthestNode();
            var countFarthestNode = instance.solution(6, new[,] {{3, 6}, {4, 3}, {3, 2}, {1, 3}, {1, 2}, {2, 4}, {5, 2}});
            //var countFarthestNode = instance.solution(6, new[,] {{1, 6}, {4, 6}, {6, 2}, {3, 6}, {3, 2}, {2, 4}, {5, 2}});
            Console.WriteLine(countFarthestNode);
        }
    }
    
    public class FarthestNode
    {
        private int[] dist;
        private int[] prev;
        public int solution(int n, int[,] edge)
        {
            var vertexs = GetVertexs(n).ToArray();
            var adjacencyDictionary = GetAdjacencyDictionary(vertexs, edge);
            var start = 1;

            dist = new int[adjacencyDictionary.Count];
            prev = new int[adjacencyDictionary.Count];
            Dijkstra(start, adjacencyDictionary, ref dist, ref prev);
            
            var max = int.MinValue;
            var maxCount = 0;
            foreach (int target in vertexs)
            {
                if (start == target) continue;
                var distance = GetShortestPathDistance(start, target, adjacencyDictionary);
                if (distance > max)
                {
                    max = distance;
                    maxCount = 0;
                }
                if (distance == max)
                {
                    maxCount++;
                }
            }

            return maxCount;
        }

        private IEnumerable<int> GetVertexs(int n)
        {
            return Enumerable.Range(1, n);
        }

        private Dictionary<int, List<int>> GetAdjacencyDictionary(IEnumerable<int> vertexs, int[,] edge)
        {
            var adjacencyList = vertexs.ToDictionary(i => i, i => new List<int>());
            for (var i = 0; i < edge.Length / 2; i++)
            {
                adjacencyList[edge[i,0]].Add(edge[i, 1]);
                adjacencyList[edge[i,1]].Add(edge[i, 0]);
            }
            return adjacencyList;
        }

        private int GetShortestPathDistance(int start, int target, IReadOnlyDictionary<int, List<int>> adjacencyDictionary)
        {

            var paths = new List<int> {target};
            while (start != target)
            {
                paths.Add(prev[target-1]);
                target = prev[target - 1];
            }

            return paths.Count;
        }

        private void Dijkstra(int start, IReadOnlyDictionary<int, List<int>> adjacencyDictionary, 
            ref int[] dist, ref int[] prev)
        {
            for (int i = 0; i < adjacencyDictionary.Count; i++)
            {
                if (start - 1 == i) continue;
                dist[i] = int.MaxValue;
                prev[i] = -1;
            }
            var queue = new Queue<int>();
            queue.Enqueue(start);
            foreach (int neighbor in adjacencyDictionary[start])
            {
                queue.Enqueue(neighbor);
            }
            
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (int neighbor in adjacencyDictionary[current])
                {
                    var alt = dist[current - 1] + 1;
                    if (alt < dist[neighbor - 1])
                    {
                        dist[neighbor - 1] = alt;
                        prev[neighbor - 1] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}