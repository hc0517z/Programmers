using System;
using System.Collections.Generic;

namespace Programmers
{
    public static class TestCamouflage
    {
        public static void Run()
        {

//            [[yellow_hat, headgear], [blue_sunglasses, eyewear], [green_turban, headgear]]	5
//            [[crow_mask, face], [blue_sunglasses, face], [smoky_makeup, face]]	3

            var instance = new Camouflage();
            var count = instance.Solution(new[,]
            {
                {"yellow_hat", "headgear"},
                {"blue_sunglasses", "eyewear"},
                {"green_turban", "headgear"},
            });
            Console.WriteLine(count);
        }
    }
    
    public class Camouflage
    {
        private Dictionary<string, int> clothesDic = new Dictionary<string, int>();
        public int Solution(string[,] clothes) {
            var answer = 1;
            for (var i = 0; i < clothes.GetLength(0) ; i++)
            {
                var type = clothes[i, 1];
                if (clothesDic.ContainsKey(type))
                {
                    clothesDic[type]++;
                }
                else
                {
                    clothesDic.Add(clothes[i, 1], 1);
                }
            }
            foreach (var item in clothesDic)
            {
                answer *= item.Value + 1; // 경우의 수 + 1 (안고를 경우의 수)
            }
            return answer - 1;  // 의상을 한개는 걸쳐야 한다 (모든 의상을 안고를 경우의 수 1를 빼줌 (0,0,0,...)
        }
    }
}