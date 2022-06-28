namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Integrator integrator = new Integrator();
            integrator.MakeTheBoard();
            integrator.BoardTheCoordinates();
            integrator.BoardTheCells();
            integrator.PrintGrid();
            integrator.BoardTheMines(integrator.SelectCell());
            while (integrator.TheMines.All(mine => mine.Detonate == false))
            {
                integrator.PrintGrid();
                integrator.Stepping(integrator.SelectCell());
            }
            Console.WriteLine("Game over!");

            Console.ReadLine();
        }
    }
}