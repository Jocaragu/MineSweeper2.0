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
            integrator.PrintGrid();
            integrator.SelectCell();
            integrator.PrintGrid();

            integrator.RevealMines();

            Console.ReadLine();
        }
    }
}