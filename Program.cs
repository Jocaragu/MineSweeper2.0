namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Integrator integrator = new Integrator();
            integrator.MakeTheBoard();
            //integrator.PrintBoard();
            integrator.BoardTheCells();
            integrator.BoardTheMines();
            Console.Clear();
            integrator.PrintGrid();
            integrator.SelectCell();
            Console.Clear();
            integrator.PrintGrid();
            integrator.SelectCell();
            Console.ReadLine();
        }
    }
}