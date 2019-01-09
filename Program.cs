using System;

namespace Programmers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SkillTree st = new SkillTree();
            var count = st.GetSkillTreeCount("CBD", new string[] {"BACDE", "CBADF", "AECB", "BDA"});
            Console.WriteLine(count);
        }
    }
}