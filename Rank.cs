using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmers
{
    public static class TestRank
    {
        public static void Run()
        {
            var r = new Rank();
            var rank = r.GetRank(5, new int[,] {{4, 3}, {4, 2}, {3, 2}, {1, 2}, {2, 5}});
            Console.WriteLine(rank);
            rank = r.GetRank(6, new int[,] {{2, 4}, {2, 3}, {4, 3}, {4, 1}, {1, 3}, {3, 6}, {1, 6}, {1, 5}, {5, 6}});
            Console.WriteLine(rank);
        }
    }

    public class Rank
    {
        private List<Player> players;
        public int GetRank(int n, int[,] results)
        {
            CreatePlayers(n);
            BuildWinLosePlayers(results);
            var answer = 0;
            foreach (var player in players)
            {
                if (CanGetRank(player)) answer++;
            }
            return answer;
        }

        private void CreatePlayers(int n)
        {
            players = new List<Player>();
            foreach (var i in Enumerable.Range(1, n))
            {
                players.Add(new Player(i));
            }
        }

        private void BuildWinLosePlayers(int[,] results)
        {
            for (int i = 0; i < results.Length / 2; i++)
            {
                var winnerId = results[i, 0];
                var loserId = results[i, 1];
                players[winnerId-1].LosePlayers.Add(players[loserId-1]);
                players[loserId-1].WinPlayers.Add(players[winnerId-1]);
            }
        }

        private void InitVisited()
        {
            foreach (Player player in players)
            {
                player.Visited = false;
            }
        }

        private bool CanGetRank(Player player)
        {
            InitVisited();
            var winCount = GetWinCount(player);
            InitVisited();
            var loseCount = GetLoseCount(player);
            return players.Count - 1 == winCount + loseCount;
        }

        private int GetWinCount(Player player)
        {
            var winCount = -1;
            var queue = new Queue<Player>();
            queue.Enqueue(player);
            player.Visited = true;
            while (queue.Any())
            {
                var currentPlayer = queue.Dequeue();
                foreach (Player winPlayer in currentPlayer.WinPlayers)
                {
                    if (!winPlayer.Visited)
                    {
                        queue.Enqueue(winPlayer);
                        winPlayer.Visited = true;
                    }
                }
                winCount++;
            }
            return winCount;
        }
        
        private int GetLoseCount(Player player)
        {
            var loseCount = -1;
            var queue = new Queue<Player>();
            queue.Enqueue(player);
            player.Visited = true;
            while (queue.Any())
            {
                var currentPlayer = queue.Dequeue();
                foreach (Player losePlayer in currentPlayer.LosePlayers)
                {
                    if (!losePlayer.Visited)
                    {
                        queue.Enqueue(losePlayer);
                        losePlayer.Visited = true;
                    }
                }
                loseCount++;
            }
            return loseCount;
        }
    }

    public class Player
    {
        private int id;
        private bool visited;
        private List<Player> winPlayers;
        private List<Player> losePlayers;

        public Player(int id)
        {
            this.id = id;
            winPlayers = new List<Player>();
            losePlayers = new List<Player>();
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public List<Player> WinPlayers
        {
            get => winPlayers;
            set => winPlayers = value;
        }

        public bool Visited
        {
            get => visited;
            set => visited = value;
        }

        public List<Player> LosePlayers
        {
            get => losePlayers;
            set => losePlayers = value;
        }
    }
}