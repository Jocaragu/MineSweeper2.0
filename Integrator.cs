using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Integrator
    {
        public static int GetUserInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

        Board TheBoard = new Board(0, 0);
        public Board MakeTheBoard()
        {
            Console.WriteLine("Let's make a board");
            int uWidth = GetUserInt("Choose the width: ");
            int uHeight = GetUserInt("Choose the height: ");
            TheBoard.Width = uWidth;
            TheBoard.Height = uHeight;
            TheBoard.Size = uWidth * uHeight;
            return TheBoard;
        }
        //public void PrintBoard()
        //{
        //    for (int j = 0; j < TheBoard.Height; j++)
        //    {
        //        for (int i = 0; i < TheBoard.Width; i++)
        //        {
        //            Console.Write("[ ]");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        List<Cell> TheCells = new List<Cell>();
        public List<Cell> BoardTheCells()
        {
            for (int i = 0; i < (TheBoard.Width * TheBoard.Height); i++)
            {
                var coordinates = new Coordinates((i % TheBoard.Width) + 1, (i / TheBoard.Width) + 1);
                var cell = new Cell(coordinates);
                TheCells.Add(cell);
            }
            return TheCells;
        }
        public void PrintGrid()
        {
            for (int i = 0; i < (TheBoard.Width); i++)
            {
                Console.Write("===");
            }
            Console.WriteLine("===");
            Console.Write("y\\x");
            for (int i = 0; i < TheBoard.Width; i++)
            {
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + " ");
                }
                else
                {
                    Console.Write(" "+ (i+1));
                }
            }
            Console.WriteLine();
            foreach (var cell in TheCells)
            {
                if (cell.Coordinates.X == 1)
                {
                    if (cell.Coordinates.Y < 10)
                    {
                        Console.Write(" " + cell.Coordinates.Y + " ");
                    }
                    else
                    {
                        Console.Write(cell.Coordinates.Y + " ");
                    }
                }
                Console.Write(cell.Label);
                if (cell.Coordinates.X == TheBoard.Width)
                {
                    Console.WriteLine("");
                }
            }
        }

        public void SteppingCell(Coordinates step)
        {
            var item = TheCells.Find(stepped => stepped.Coordinates.Matches(step));
            if (item != null)
            {
                item.SteppingOn(true);
            }
        }
        public void SelectCell()
        {
            Console.WriteLine("Select a cell within the coordinates");
            int xSelection = GetUserInt("x: ");
            int ySelection = GetUserInt("y: ");
            Coordinates selection = new(xSelection, ySelection);
            SteppingCell(selection);
            SteppingMine(selection);
        }

        List<Mine> TheMines = new List<Mine>();
        public List<Mine> BoardTheMines()
        {
            for (int i = 0; i < (TheBoard.Size/4); i++)
            {
                var coordinates = new Coordinates((i % TheBoard.Width) + 1, (i / TheBoard.Width) + 1);
                var mine = new Mine(coordinates);
                TheMines.Add(mine);
            }
            return TheMines;
        }
        public void SteppingMine(Coordinates step)
        {
            var item = TheMines.Find(stepped => stepped.Coordinates.Matches(step));
            if (item != null)
            {
                item.SteppingOn(true);
            }
        }

        public void RevealMines()
        {
            foreach(var cell in TheCells)
            {
                foreach(var mine in TheMines)
                {
                    if (mine.Coordinates.Matches(cell.Coordinates))
                    {
                        cell.Label = " ☼ ";
                    }
                }
            }
            PrintGrid();
        }
    }
}
