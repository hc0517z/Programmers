using System;
using System.Linq;

namespace Programmers
{
    public static class TestBinaryGap
    {
        public static void Run()
        {
            var instance = new BinaryGap();
            var result = instance.solution(32);
            Console.WriteLine(result);
        }
    }
    
    public class BinaryGap
    {
        public int solution(int n)
        {
            var binary = Convert.ToString(n, 2);
            var splitArray = binary.Split('1');
            var lengthArray = splitArray.Select((s, i) => i == 0 | i == splitArray.Length -1 ? 0 : s.Length);
            return lengthArray.Max();
        }
    }
}