using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Integrator
    {
        private Board TheBoard = new(0, 0);
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

        public List<Coordinates> TheCoordinates = new();
        public List<Coordinates> BoardTheCoordinates()
        {
            for (int i = 0; i < TheBoard.Size; i++)
            {
                var coordinates = new Coordinates((i % TheBoard.Width) + 1, TheBoard.Height - (i / TheBoard.Width));
                TheCoordinates.Add(coordinates);
            }
            return TheCoordinates;
        }

        public List<Cell> TheCells = new();
        public List<Cell> BoardTheCells()
        {
            for (int i = 0; i < (TheBoard.Size); i++)
            {
                var cell = new Cell(TheCoordinates[i]);
                TheCells.Add(cell);
            }
            return TheCells;
        }
        public List<Mine> TheMines = new();
        private static readonly Random rng = new Random();
        public List<Mine> BoardTheMines(Coordinates seed)
        {
            List<Coordinates> rngCoordinates = TheCoordinates;
            Stepping(seed);
            rngCoordinates.RemoveAll(safe => safe.Matches(seed));
            rngCoordinates.OrderBy(_ => rng.Next()).ToList();
            for (int i = 0; i < (TheBoard.Size - 1); i++)
            {
                var mine = new Mine(rngCoordinates[i]);
                TheMines.Add(mine);
            }
            return TheMines;
        }
        public void PrintGrid()
        {
            Console.Clear();
            Console.WriteLine("   ┌");
            foreach (var cell in TheCells)
            {
                if (cell.Coordinates.X == 1)
                {
                    if (cell.Coordinates.Y < 10)
                    {
                        Console.Write(" " + cell.Coordinates.Y + " │");
                    }
                    else
                    {
                        Console.Write(cell.Coordinates.Y + " │");
                    }
                    Console.Write(cell.Label);
                }
                else if (cell.Coordinates.X == TheBoard.Width)
                {
                    Console.Write(cell.Label);
                    if (cell.Coordinates.Y > 1)
                    {
                        Console.Write("\n   ┤\n");
                    }
                    else
                    {
                        Console.Write("\n   ┼");
                    }
                }
                else
                {
                    Console.Write(cell.Label);
                }
            }
            for (int i = 1; i < TheBoard.Width; i++)
            {
                Console.Write("───┬");
                if (i == (TheBoard.Width - 1))
                {
                    Console.WriteLine("───┘");
                }
            }
            for (int i = 0; i < TheBoard.Width + 1; i++)
            {
                if (i < 10)
                {
                    Console.Write(" " + i + "  ");
                }
                else
                {
                    Console.Write(" " + i + " ");
                }
            }
            Console.WriteLine("\n");
        }
        public void Stepping(Coordinates step)
        {
            var cell = TheCells.Find(stepped => stepped.Coordinates.Matches(step));
            var mine = TheMines.Find(stepped => stepped.Coordinates.Matches(step));
            if (mine != null)
            {
                mine.SteppingOn(true);
                RevealMines();
                Console.WriteLine(mine.Status);
            }
            else if (cell != null)
            {
                cell.SteppingOn(true);
            }
        }
        public Coordinates? Selection { get; set; }
        public Coordinates SelectCell()
        {
            Console.WriteLine("Select a cell within the coordinates");
            int xSelection = MyTools.GetUserInt("x: ");
            int ySelection = MyTools.GetUserInt("y: ");
            Selection = new Coordinates(xSelection, ySelection);
            return Selection;
        }
        public void RevealMines()
        {
            foreach (var cell in TheCells)
            {
                cell.SteppingOn(true);
                foreach (var mine in TheMines)
                {
                    if (mine.Coordinates.Matches(cell.Coordinates))
                    {
                        cell.Label = "[☼] ";
                    }
                }
            }
            PrintGrid();
        }
    }
}
