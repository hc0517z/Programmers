using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmers
{
    public static class TestVisitLength
    {
        public static void Run()
        {
            VisitLength vl = new VisitLength();
            var length1 = vl.GetVisitLength("ULURRDLLU");
            Console.WriteLine(length1);
            var length2 = vl.GetVisitLength("LULLLLLLU");
            Console.WriteLine(length2);
        }
    }
    
//        5 x 5
//        ULURRDLLU	7
//        LULLLLLLU	7
    public class VisitLength
    {
        private Position currentPosition;
        private List<Way> ways;
        
        public int GetVisitLength(string dirs)
        {
            currentPosition = new Position();
            ways = new List<Way>();
            
            int answer = 0;
            foreach (char dir in dirs)
            {
                if (VisitFirst(dir))
                {
                    answer++;
                }
            }
            
            return answer;
        }

        private bool VisitFirst(char dir)
        {
            Position nextPosition = null;
            if (!GetNextPosition(dir, ref nextPosition)) return false;
            if (nextPosition == null) return false;
            Way newWay = null;
            var visitFirst = CheckFirst(nextPosition, ref newWay);
            Move(newWay);
            return visitFirst;
        }

        private void Move(Way newWay)
        {
            ways.Add(newWay);
            currentPosition.X = newWay.End.X;
            currentPosition.Y = newWay.End.Y;
        }

        private bool CheckFirst(Position nextPosition, ref Way newWay)
        {
            newWay = new Way(currentPosition.Clone() as Position, nextPosition.Clone() as Position);
            var copyWay = newWay;
            var isContain = ways.Any(way => way.Equals(copyWay));
            return !isContain;
        }

        private bool GetNextPosition(char dir, ref Position nextPosition)
        {
            var clonePosition = currentPosition.Clone() as Position;
            if (clonePosition == null) return false;
            switch (dir)
            {
                case 'U':
                    clonePosition.Y++;
                    break;
                case 'D':
                    clonePosition.Y--;
                    break;
                case 'R':
                    clonePosition.X++;
                    break;
                case 'L':
                    clonePosition.X--;
                    break;
                default: return false;
            }

            if (-5 <= clonePosition.X & clonePosition.X <= 5 &
                -5 <= clonePosition.Y & clonePosition.Y <= 5)
            {
                nextPosition = clonePosition;
                return true;
            }
            return false;
        }
    }
    
    public class Way
    {
        public Way(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        public Position Start { get; set; }
        public Position End { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Way) obj);
        }

        private bool Equals(Way other)
        {
            return (Equals(Start, other.Start) && Equals(End, other.End)) || (Equals(Start, other.End) && Equals(End, other.Start));
        }
    }

    public class Position : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public object Clone()
        {
            return new Position {X = this.X, Y = this.Y};
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        private bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}