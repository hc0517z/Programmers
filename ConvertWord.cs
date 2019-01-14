using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmers
{
    public static class TestConvertWord
    {
        public static void Run()
        {
            var st = new ConvertWord();
            var count = st.Solution("hit", "cog", new[] {"hot", "dot", "dog", "lot", "log", "cog"});
            Console.WriteLine(count);
            count = st.Solution("hit", "cog", new[] {"hot", "dot", "dog", "lot", "log"});
            Console.WriteLine(count);
            count = st.Solution("hit", "cog", new[] {"hot", "dot", "dog", "cog"});
            Console.WriteLine(count);
        }
    }
    
//    begin	target	words	return
//    hit	cog	[hot, dot, dog, lot, log, cog]	4
//    hit	cog	[hot, dot, dog, lot, log]    0
    public class ConvertWord
    {
        private List<Word> wordsGraph;
        private Stack<Word> stack;
        private int answer = 0;

        public int Solution(string begin, string target, string[] words)
        {
            answer = 0;
            wordsGraph = new List<Word> {new Word {Name = begin}};
            wordsGraph.AddRange(words.Select(s => new Word {Name = s}).ToList());
            foreach (var word in wordsGraph)
            {
                foreach (var word1 in wordsGraph)
                {
                    word.AddAdjacencyWord(word1);
                }
            }

            var targetWord = wordsGraph.Find(word => word.Name == target);
            if (targetWord == null) return 0;
            stack = new Stack<Word>();
            dfs(wordsGraph.First(), targetWord);
            return answer;
        }

        public void dfs(Word beginWord, Word targetWord)
        {
            stack.Push(beginWord);
            while (stack.Any())
            {
                var current = stack.Pop();
                if (current.Name == targetWord.Name) return;
                current.IsVisited = true;
                answer++;
                foreach (Word word in current.AdjacencyWord)
                {
                    if (!word.IsVisited)
                    {
                        stack.Push(word);
                    }
                }
            }
            answer = 0;
        }
    }

    public class Word
    {
        private string name;
        private List<Word> adjacencyWord;
        private bool isVisited;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<Word> AdjacencyWord
        {
            get => adjacencyWord;
            set => adjacencyWord = value;
        }

        public bool IsVisited
        {
            get => isVisited;
            set => isVisited = value;
        }

        public void AddAdjacencyWord(Word word)
        {
            if (adjacencyWord == null) adjacencyWord = new List<Word>();
            if (this.name == word.name) return;
            var isNeighbor = this.name.Zip(word.name, (c1, c2) => c1 == c2 ? 0 : 1).Sum() == 1;
            if (isNeighbor)
                this.adjacencyWord.Add(word);
        }
    }
}