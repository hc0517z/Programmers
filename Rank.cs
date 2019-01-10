using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmers
{
    public static class TestRank
    {
        public static void Run()
        {
            Rank r = new Rank();

            var rank = r.GetRank(5, new int[,] {{4, 3}, {4, 2}, {3, 2}, {1, 2}, {2, 5}});
            Console.WriteLine(rank);
        }
    }

    public class Rank
    {
        public int GetRank(int n, int[,] results) 
        {
            int answer = 0;
            return answer;
        }
    }
}