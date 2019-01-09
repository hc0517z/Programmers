using System;

namespace Programmers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Rank r = new Rank();

            var rank = r.GetRank(5, new int[,] {{4, 3}, {4, 2}, {3, 2}, {1, 2}, {2, 5}});
            Console.WriteLine(rank);
//            SkillTree st = new SkillTree();
//            var count = st.GetSkillTreeCount("CBD", new string[] {"BACDE", "CBADF", "AECB", "BDA"});
//            Console.WriteLine(count);
        }
    }
}