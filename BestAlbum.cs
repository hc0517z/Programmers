using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmers
{
    public static class TestBestAlbum
    {
        public static void Run()
        {
            var instance = new BestAlbum();
            var count = instance.Solution(new[] {"classic", "pop", "classic", "classic", "pop"}, new[] {500, 600, 150, 800, 2500});

            foreach (int i in count)
            {
                Console.Write(i + ", ");
            }
        }
    }
    
    public class BestAlbum
    {
        public int[] Solution(string[] genres, int[] plays)
        {
            var dic = new Dictionary<string, List<Song>>();
            for (var i = 0; i < genres.Length; i++)
            {
                var genre = genres[i];
                var play = plays[i];
                if (!dic.ContainsKey(genre)) dic.Add(genre, new List<Song>());
                dic[genre].Add(new Song(i, play));
                dic[genre] = dic[genre].OrderByDescending(song => song.Play).ToList();
            }
            var sortDic = dic.OrderByDescending(pair => pair.Value.Sum(song => song.Play));
            var filteredDic = sortDic.Select(pair => pair.Value.Take(2).Select(song => song.Id).ToArray());
            var answerList = new List<int>();
            foreach (var ints in filteredDic)
            {
                answerList.AddRange(ints);
            }
            return answerList.ToArray();
        }
    }

    public class Song
    {
        private int id;
        private int play;

        public Song(int id, int play)
        {
            this.id = id;
            this.play = play;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Play
        {
            get { return play; }
            set { play = value; }
        }
    }
}