namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Integrator integrator = new();
            integrator.MakeTheBoard();
            integrator.BoardTheCoordinates();
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