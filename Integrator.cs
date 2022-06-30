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
            if (uWidth < 5) { uWidth = 5;}
            int uHeight = MyTools.GetUserInt("Choose the height: ");
            if (uHeight < 5) { uHeight = 5;}
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
        public List<Mine> BoardTheMines(Coordinates seed)
        {
            List<Coordinates> SafeZone = CreatePerimeter(seed);
            SafeZone.Add(seed);
            List<Coordinates> rngCoordinates = TheCoordinates;
            rngCoordinates.RemoveAll(r => SafeZone.Exists(s => (s.X,s.Y) == (r.X,r.Y)));
            //rngCoordinates.RemoveAll(safe => safe.Matches(seed));
            MyTools.FisherYates(rngCoordinates);
            for (int i = 0; i < (TheBoard.Size / 10); i++)
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
        public void HintTheCells()
        {
            foreach (Cell hintedCell in TheCells)
            {
                List<Coordinates> CellPerimeter = CreatePerimeter(hintedCell.Coordinates);
                var minesAroundCell = (
                    from mineA in TheMines
                    join coordinatesB in CellPerimeter
                    on new { mineA.Coordinates.X, mineA.Coordinates.Y }
                    equals new { coordinatesB.X, coordinatesB.Y }
                    select new { mineA }).ToList();
                hintedCell.DetectedAdjacentMines(minesAroundCell.Count);
                CellPerimeter.Clear();
            }
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
                
                if (cell.AdjacentMines == 0)
                {
                    List<Coordinates> CellPerimeter = CreatePerimeter(cell.Coordinates);
                    foreach (var coordinate in CellPerimeter)
                    {
                        foreach (var item in TheCells)
                        {
                            if (item.Coordinates.Matches(coordinate) && item.Revealed==false)
                            {
                                Stepping(coordinate);
                            }
                        }
                    }
                }

                //Console.ReadLine();
            }
        }
        public Coordinates? SelectedCoordinates { get; set; }
        public Coordinates SelectCoordinates()
        {
            Console.WriteLine("Select a cell within the coordinates");
            int xSelection = MyTools.GetUserInt("x: ");
            int ySelection = MyTools.GetUserInt("y: ");
            SelectedCoordinates = new Coordinates(xSelection, ySelection);
            return SelectedCoordinates;
        }
        public List<Coordinates> CreatePerimeter(Coordinates p)
        {
            List<Coordinates> Perimeter = new();

            for (int j = p.Y - 1; j < p.Y + 2; j++)
            {
                for (int i = p.X - 1; i < p.X + 2; i++)
                {
                    Coordinates perimeterCoordinates = new(i, j);
                    if (!(perimeterCoordinates.X == p.X & perimeterCoordinates.Y == p.Y))
                    {
                        Perimeter.Add(perimeterCoordinates);
                    }
                }
            }
            return Perimeter;
        }
        
        public void RevealMines()
        {
            foreach (var cell in TheCells)
            {
                foreach (var mine in TheMines)
                {
                    if (mine.Coordinates.Matches(cell.Coordinates))
                    {
                        cell.Label = " ☼  ";
                    }
                }
            }
            PrintGrid();
        }
    }
}
