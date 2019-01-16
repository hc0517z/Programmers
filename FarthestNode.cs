using System;
using System.Collections.Generic;
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
            var countFarthestNode = instance.solution(6, new[,] {{1, 6}, {4, 6}, {6, 2}, {3, 6}, {3, 2}, {2, 4}, {5, 2}});
            Console.WriteLine(countFarthestNode);
        }
    }
    
    public class FarthestNode
    {
        public int solution(int n, int[,] edge)
        {
            var vertexs = GetVertexs(n).ToArray();
            var adjacencyDictionary = GetAdjacencyDictionary(vertexs, edge);
            var max = 0;
            var maxCount = 0;
            var start = 1;
            foreach (int target in vertexs)
            {
                if (start == target) continue;
                
                // target -> start : backtracking
                var cnt = GetTraverseCount(n, target, start, adjacencyDictionary);
                if (cnt > max)
                {
                    max = cnt;
                    maxCount = 0;
                }
                if (cnt == max) maxCount++;
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

        private int GetTraverseCount(int n, int start, int target, IReadOnlyDictionary<int, List<int>> adjacencyDictionary)
        {
            var traverseCount = 0;
            var visitedList = new bool[n];
            var stack = new Stack<int>();
            stack.Push(start);
            visitedList[start-1] = true;

            while (stack.Any())
            {
                var current = stack.Pop();
                var adjacencyList = adjacencyDictionary[current];
                if (adjacencyList.Contains(target))
                {
                    stack.Push(target);
                    visitedList[target - 1] = true;
                }
                else
                {
                    foreach (var i in adjacencyList)
                    {
                        if (!visitedList[i - 1])
                        {
                            stack.Push(i);
                            visitedList[i - 1] = true;
                        }
                    }
                }
                traverseCount++;
            }
            
            return traverseCount;
        }
    }
}