using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Integrator
    {
        Board TheBoard = new(0, 0);
        public Board MakeTheBoard()
        {
            Console.WriteLine("Let's make a board");
            int uWidth = MyTools.GetUserInt("Choose the width: ");
            int uHeight = MyTools.GetUserInt("Choose the height: ");
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

        List<Coordinates> TheCoordinates = new();
        public List<Coordinates> BoardTheCoordinates()
        {
            for (int i = 0; i < TheBoard.Size; i++)
            {
                var coordinates = new Coordinates((i % TheBoard.Width) + 1, (i / TheBoard.Width) + 1);
                TheCoordinates.Add(coordinates);
            }
            return TheCoordinates;
        }
        
        List<Cell> TheCells = new();
        public List<Cell> BoardTheCells()
        {
            for (int i = 0; i < (TheBoard.Size); i++)
            {
                var cell = new Cell(TheCoordinates[i]);
                TheCells.Add(cell);
            }
            return TheCells;
        }
        List<Mine> TheMines = new();
        private static readonly Random rng = new Random();
        public List<Mine> BoardTheMines()
        {
            List<Coordinates> rngCoordinates = TheCoordinates.OrderBy(_=>rng.Next()).ToList();
            for (int i = 0; i < (TheBoard.Size / 4); i++)
            {
                var mine = new Mine(rngCoordinates[i]);
                TheMines.Add(mine);
            }
            return TheMines;
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
                    Console.Write(" " + (i + 1));
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
        public void SteppingMine(Coordinates step)
        {
            var item = TheMines.Find(stepped => stepped.Coordinates.Matches(step));
            if (item != null)
            {
                item.SteppingOn(true);
                Console.WriteLine(item.Status);
            }
        }
        public void SelectCell()
        {
            Console.WriteLine("Select a cell within the coordinates");
            int xSelection = MyTools.GetUserInt("x: ");
            int ySelection = MyTools.GetUserInt("y: ");
            Coordinates selection = new(xSelection, ySelection);
            SteppingCell(selection);
            SteppingMine(selection);
        }
        public void RevealMines()
        {
            foreach (var cell in TheCells)
            {
                foreach (var mine in TheMines)
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
