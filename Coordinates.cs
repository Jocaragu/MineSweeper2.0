using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Coordinates
    {
        public int X { get; }
        public int Y { get; }
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;  
        }
        public bool Matches(Coordinates matching)
        {
            return matching.X == X && matching.Y == Y;
        }
    }
}
