using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Size = width * height;
        }
    }
}
