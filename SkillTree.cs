using System;
using System.Linq;

namespace Programmers
{
    //    CBD	[BACDE, CBADF, AECB, BDA]	2
    public class SkillTree
    {
        public int GetSkillTreeCount(string skills, string[] skill_trees)
        {
            int answer = 0;
            
            foreach (string skillTree in skill_trees)
            {
                var index = 0;
                answer++;
                foreach (char skill in skillTree)
                {
                    var searchIndex = skills.IndexOf(skill);
                    if (searchIndex == index)
                    {
                        index++;
                    }
                    else if (searchIndex > index)
                    {
                        answer--;
                        break;
                    }
                }
            }

            return answer;

            //return skill_trees.Count(skillTree => CheckCondition(skill, skillTree));
        }

        private bool CheckCondition(string skill, string skillTree)
        {
            if (string.IsNullOrEmpty(skill)) return true;
            if (string.IsNullOrEmpty(skillTree)) return false;
            
            if (skillTree.Contains(skill.Last()))
            {
                var findSkillIndex = skillTree.IndexOf(skill.Last());
                return CheckCondition(skill.Substring(0, skill.Length - 1), skillTree.Substring(0, findSkillIndex));
            }

            return CheckCondition(skill.Substring(0, skill.Length - 1), skillTree);
        }
    }
}