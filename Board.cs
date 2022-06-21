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

        public Board(int uWidth, int uHeight)
        {
            Width = uWidth;
            Height = uHeight;
            Size = uWidth * uHeight;
        }
        public void PrintBoard()
        {
            for (int i = 0; i < Size; i++)
            {

            }
        }
    }
}
