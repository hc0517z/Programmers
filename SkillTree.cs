using System;
using System.Linq;

namespace Programmers
{
    //    CBD	[BACDE, CBADF, AECB, BDA]	2
    public class SkillTree
    {
        public int GetSkillTreeCount(string skill, string[] skill_trees) {
            int answer = 0;

            foreach (string skillTree in skill_trees)
            {
                var newSkillTree =  skillTree.Select(c => skill.IndexOf(c)).Where(i => i != -1).ToArray();
                answer++;
                for (int i = 0; i < newSkillTree.Length-1; i++)
                {
                    if (newSkillTree[i] > newSkillTree[i + 1])
                    {
                        answer--;
                        break;
                    }
                }
            }
            
            return answer;
        }
    }
}