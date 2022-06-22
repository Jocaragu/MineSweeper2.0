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
        public List<Cell> TheCells = new List<Cell>();
        public List<Cell> EnlistCells()
        {
            var theCells = new List<Cell>();
            for (int i = 0; i < (Width * Height); i++)
            {
                var coordinates = new Coordinates((i % Width) + 1, (i / Width) + 1);
                var cell = new Cell(coordinates);
                theCells.Add(cell);
            }
            TheCells = theCells;
            return TheCells;
        }
        public void PrintGrid()
        {
            for (int i = 0; i < (Width); i++)
            {
                Console.Write("===");
            }
            Console.WriteLine("===");
            Console.Write("y\\x");
            for (int i = 0; i < Width; i++)
            {
                Console.Write(" "+(i+1)+" ");
            }
            Console.WriteLine();
            foreach (var cell in TheCells)
            {
                if (cell.Coordinates.X == 1)
                {
                    Console.Write(" "+cell.Coordinates.Y+" ");
                }
                Console.Write(cell.Label);
                if (cell.Coordinates.X == Width)
                {
                    Console.WriteLine("");
                }
            }
        }
        public List<Cell> GetTheCells()
        {
            return TheCells;
        }
        public void ProbingCells(Coordinates probe)
        {
            var item = TheCells.Find(probedCell => probedCell.Coordinates.Matches(probe));
            if (item != null)
            {
                item.SteppingOn(true);
            }
        }
    }
}
