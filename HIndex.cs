using System;
using System.Linq;

namespace Programmers
{
    public static class TestHIndex
    {
//        case 1) citations : [10, 100]                   H-Index : 2
//        case 2)  citations : [6, 6, 6, 6, 6, 6]        H-Index : 6
//        case 3) citations : [2, 2, 2]                     H-Index : 2

        public static void Run()
        {
            var instance = new HIndex();
            var count = instance.solution(new[] {10, 100});
            //var count = instance.solution(new[] {6, 6, 6, 6, 6, 6});
            //var count = instance.solution(new[] {2, 2, 2});
            //var count = instance.solution(new[] {3, 0, 6, 1, 5});
            Console.WriteLine(count);
        }
    }
    
    public class HIndex
    {
        public int solution(int[] citations) 
        {
            var sortDic = citations.OrderByDescending(i => i).ToArray();
            for (int i = 0; i < sortDic.Length; i++)
            {
                if (i >= sortDic[i]) return i;
            }
            return sortDic.Length;
        }
    }
}