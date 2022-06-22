using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class UI
    {
        public static int GetUserInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void StartGame()
        {
            Console.WriteLine("Welcome, choose the size of your board");
            int uWidth = GetUserInt("Width: ");
            int uHeight = GetUserInt("Height: ");
            Board board = new(uWidth, uHeight);
            board.EnlistCells();
            board.PrintGrid();
        }
    }
}
