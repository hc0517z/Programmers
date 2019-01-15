using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmers
{
//    n	computers	return
//    3	[[1, 1, 0], [1, 1, 0], [0, 0, 1]]	2
//    3	[[1, 1, 0], [1, 1, 1], [0, 1, 1]]	1
    public static class TestNetwork
    {
        public static void Run()
        {
            var r = new Network();
            //var countNetwork = r.solution(3, new[,] {{1, 1, 0}, {1, 1, 0}, {0, 0, 1}});
            //Console.WriteLine(countNetwork);
            var countNetwork = r.solution(3, new[,] {{1, 1, 0}, {1, 1, 1}, {0, 1, 1}});
            Console.WriteLine(countNetwork);
        }
    }
    
    public class Network
    {
        public int solution(int n, int[,] computers) {
            var traverseSortList = new List<List<int>>();
            foreach (int num in Enumerable.Range(0, n))
            {
                var traverse = Traverse(n, num, computers);
                var orderTraverse = traverse.OrderBy(i => i).ToList();
                if (!traverseSortList.Any(ints => ints.SequenceEqual(orderTraverse)))
                {
                    traverseSortList.Add(orderTraverse);
                }
            }
            return traverseSortList.Count;
        }

        private List<int> Traverse(int n, int root, int[,] computers)
        {
            var traverse = new List<int>();
            var stack = new Stack<int>();
            var visitedArray = new bool[n];
            stack.Push(root);
            visitedArray[root] = true;
            while (stack.Any())
            {
                var current = stack.Pop();
                traverse.Add(current);
                for (int i = 0; i < computers.Length / n; i++)
                {
                    if (!visitedArray[i])
                    {
                        if (computers[current, i] == 1)
                        {
                            stack.Push(i);
                            visitedArray[i] = true;
                        }
                    }
                }
            }
            return traverse;
        }
    }
}